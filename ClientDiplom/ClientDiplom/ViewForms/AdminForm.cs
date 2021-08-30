using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using ClientDiplom.ClientLogic;
using ClientDiplom.Data;
using System.Net.Http.Json;
using System.Threading;

namespace ClientDiplom.ViewForms
{
    public partial class AdminForm : Form
    {
        private HttpClient client;
        private BoxFiller boxFiller;

        public AdminForm(HttpClient client)
        {
            InitializeComponent();

            this.client = client;
            boxFiller = new BoxFiller(client);
        }


        private async void AdminForm_Load(object sender, EventArgs e)
        {
            await boxFiller.GetCategories(CategoriesClb, "get-all-categories");

            CategoriesClb.SetItemChecked(0, true);

            await boxFiller.ShowDocuments(DocumentsLB, CategoriesClb);

            await boxFiller.GetAllUsers(DGV);
        }

        private void toolStripAddUserBtn_Click(object sender, EventArgs e)
        {
            ManageUserForm manageUserForm = new ManageUserForm(client, "Добавление пользователя", "Добавить", DGV);
            manageUserForm.Show();
        }

        private async void toolStripDelUserBtn_Click(object sender, EventArgs e)
        {
            var response = await client.DeleteAsync($"del-user/{DGV.CurrentRow.Cells[1].Value}");

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Пользователь успешно удален!");

                await boxFiller.GetAllUsers(DGV);
            }
            else
            {
                MessageBox.Show("Ошибка при удалении пользователя!");
            }
        }

        private void toolStripEditUserBtn_Click(object sender, EventArgs e)
        {
            ManageUserForm manageUserForm = new ManageUserForm(client, "Редактирование пользователя", "Применить изменения", DGV);
            manageUserForm.Show();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (CategoriesClb.CheckedItems != null)
            {
                List<string> categories = new List<string>();

                foreach (var item in CategoriesClb.CheckedItems)
                {
                    categories.Add(item.ToString());
                }

                GlobalSearchForm globalSearchForm = new GlobalSearchForm(client, SearchForm.DelCarret(SearchField.Text), categories);
                globalSearchForm.Show();
            }
            else
            {
                MessageBox.Show("Выберите хоят бы одно категорию для поиска!");
            }
        }

        private async void toolStripAddDocBtn_Click(object sender, EventArgs e)
        {
            using (OFD)
            {
                OFD.Filter = "Txt files (*.txt)|*.txt|Rtf files (*.rtf)|*.rtf|Doc files (*.doc)|*.doc|Docx files (*.docx)|*.docx|All files (*.*)|*.*";

                string documentPath;

                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    documentPath = OFD.FileName;

                    if (documentPath.EndsWith(DocumentFormats.TXT) ||
                            documentPath.EndsWith(DocumentFormats.RTF) ||
                            documentPath.EndsWith(DocumentFormats.DOC) ||
                            documentPath.EndsWith(DocumentFormats.DOCX)
                        )
                    {
                        ManageDocumentForm manageDocumentForm = new ManageDocumentForm
                        (
                            client,
                            "Добавление документа",
                            "Добавить",
                            new DocumentData
                            {
                                Path = documentPath,
                                Name = Path.GetFileName(documentPath)
                            }
                        );

                        manageDocumentForm.ShowDialog();

                        await boxFiller.ShowDocuments(DocumentsLB, CategoriesClb);
                    }
                    else
                    {
                        MessageBox.Show($"Формат файла {Path.GetFileName(documentPath)} не поддерживаются данным приложением!");
                    }
                }
            }
        }

        private async void toolStripDelDocBtn_Click(object sender, EventArgs e)
        {
            if (DocumentsLB.SelectedItem != null)
            {
                var documentName = DocumentsLB.SelectedItem.ToString();

                var response = await client.DeleteAsync($"del-document/{documentName}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Документ успешно удален!");
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении документов!");
                }

                await boxFiller.ShowDocuments(DocumentsLB, CategoriesClb);
            }
        }

        private async void toolStripEditDocBtn_Click(object sender, EventArgs e)
        {
            if (DocumentsLB.SelectedItem != null)
            {
                ManageDocumentForm manageDocumentForm = new ManageDocumentForm
                (
                    client,
                    "Редактирование документа",
                    "Применить изменения",
                    new DocumentData { Name = DocumentsLB.SelectedItem.ToString() }
                );

                manageDocumentForm.ShowDialog();

                await boxFiller.ShowDocuments(DocumentsLB, CategoriesClb);
            }
        }

        private async void toolStripDownloadDocBtn_Click(object sender, EventArgs e)
        {
            if (DocumentsLB.SelectedItem != null)
            {
                SFD.Title = "Сохранение документа";

                var documentName = DocumentsLB.SelectedItem.ToString();

                SFD.FileName = documentName;

                var extension = Path.GetExtension(documentName);

                SFD.DefaultExt = extension;
                SFD.Filter = $"{extension.Replace(".", "")} files |* {extension}";


                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    var response = await client.PostAsJsonAsync($"download-document", documentName);

                    if (response.IsSuccessStatusCode)
                    {
                        var documentBytes = await response.Content.ReadFromJsonAsync<byte[]>();

                        using (var fileStream = new FileStream(SFD.FileName, FileMode.Create, FileAccess.Write))
                        {
                            await fileStream.WriteAsync(documentBytes, 0, documentBytes.Length);
                        }

                        MessageBox.Show("Файл успешно скачан!");
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private async void toolStripAddCategBtn_Click_1(object sender, EventArgs e)
        {
            ManageCategoryForm manageCategoryForm = new ManageCategoryForm(client, "Добавление категории", "Добавить");
            manageCategoryForm.ShowDialog();

            await boxFiller.GetCategories(CategoriesClb, "get-all-categories");

            CategoriesClb.SetItemChecked(0, true);
        }

        private async void toolStripDelCategBtn_Click_1(object sender, EventArgs e)
        {
            if (CategoriesClb.SelectedItem != null && CategoriesClb.SelectedIndex != 0)
            {
                var response = await client.DeleteAsync($"del-category/{CategoriesClb.SelectedItem}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Категория успешно удалена!");

                    await boxFiller.GetCategories(CategoriesClb, "get-all-categories");

                    CategoriesClb.SetItemChecked(0, true);

                    await boxFiller.ShowDocuments(DocumentsLB, CategoriesClb);
                }
                else
                {
                    MessageBox.Show("Ошибка при удалении документа!");
                }
            }
            else
            {
                MessageBox.Show("Невозможно удалить данную категорию!");
            }
        }

        private async void toolStripEditBtn_Click_1(object sender, EventArgs e)
        {
            ManageCategoryForm manageCategoryForm = new ManageCategoryForm(client, "Редактирование категории", "Применить изменения", CategoriesClb.SelectedItem.ToString());
            manageCategoryForm.ShowDialog();

            await boxFiller.GetCategories(CategoriesClb, "get-all-categories");

            CategoriesClb.SetItemChecked(0, true);
        }

        private void DocumentsLB_DoubleClick_1(object sender, EventArgs e)
        {
            if (DocumentsLB.SelectedItem != null)
            {
                SearchForm searchForm = new SearchForm(client, DocumentsLB.SelectedItem.ToString(), new CancellationTokenSource());
                searchForm.Show();
            }
        }

        private async void CategoriesClb_Click(object sender, EventArgs e)
        {
            int idx;

            if (CategoriesClb.SelectedIndex != -1)
            {
                idx = CategoriesClb.SelectedIndex;

                if (CategoriesClb.CheckedIndices.Contains(CategoriesClb.SelectedIndex))
                {
                    CategoriesClb.SetItemChecked(CategoriesClb.SelectedIndex, false);
                }
                else
                {
                    CategoriesClb.SetItemChecked(CategoriesClb.SelectedIndex, true);
                }

                CategoriesClb.SelectedIndex = -1;

                await boxFiller.ShowDocuments(DocumentsLB, CategoriesClb);

                CategoriesClb.SelectedIndex = idx;
            }
        }

        private async void toolStripResearchBtn_Click(object sender, EventArgs e)
        {
            if (DocumentsLB.SelectedItem != null)
            {
                var response = await client.PostAsJsonAsync("get-count-symbols-document", DocumentsLB.SelectedItem.ToString());

                if (response.IsSuccessStatusCode)
                {
                    int countSymDoc = await response.Content.ReadFromJsonAsync<int>();

                    RowsAndGraphsForm scheduledStringsForm = new RowsAndGraphsForm(client, DocumentsLB.SelectedItem.ToString(), countSymDoc);
                    scheduledStringsForm.Show();
                }
                else
                {
                    MessageBox.Show("Ошибка при получении количества символов документа!");
                }
            }
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Dispose();
        }
    }
}
