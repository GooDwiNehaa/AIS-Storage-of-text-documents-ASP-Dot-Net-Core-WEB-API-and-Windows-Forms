using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using ClientDiplom.ClientLogic;
using ClientDiplom.Data;

namespace ClientDiplom.ViewForms
{
    public partial class ManageDocumentForm : Form
    {
        private HttpClient client;

        private BoxFiller boxFiller;
        private FormClosingEditer closingEditer;

        private string name;
        private string path;
        private string ext;

        private DocumentReader documentReader;

        private bool changeDocument = false;

        public ManageDocumentForm(HttpClient client, string formName, string btnName, DocumentData documentData)
        {
            InitializeComponent();

            this.client = client;

            boxFiller = new BoxFiller(client);
            closingEditer = new FormClosingEditer();

            ext = Path.GetExtension(documentData.Name);
            name = documentData.Name.Replace(ext, "");
            path = documentData.Path;
            

            documentReader = new DocumentReader();

            this.Text = formName;
            this.AddApply.Text = btnName;
        }

        private async void AddApply_Click(object sender, EventArgs e)
        {
            if (this.Text == "Добавление документа" && this.AddApply.Text == "Добавить")
            {
                DocumentCategoriesData documentCategoriesData = new DocumentCategoriesData();

                foreach (string item in CategoriesCLB.CheckedItems)
                {
                    documentCategoriesData.Categories.Add(item);
                }

                if (documentCategoriesData.Categories.Any())
                {
                    documentCategoriesData.DocumentName = name + ext;

                    documentCategoriesData.DocumentFile = File.ReadAllBytes(path);

                    var response = await client.PostAsJsonAsync("add-document", documentCategoriesData);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Документ {documentCategoriesData.DocumentName} успешно добавлен!");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении документа!");
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Выберите хотя бы одну категорию документа!");
                }
            }
            else if (this.Text == "Редактирование документа" && this.AddApply.Text == "Применить изменения")
            {
                DocumentEditData documentEditData = new DocumentEditData();

                foreach (string item in CategoriesCLB.CheckedItems)
                {
                    documentEditData.Categories.Add(item);
                }

                if (documentEditData.Categories.Any())
                {
                    documentEditData.DocumentOldName = name + ext;
                    documentEditData.DocumentNewName = DocumentNameTB.Text + ext;

                    documentEditData.DocumentContent = RTB.Text;

                    var response = await client.PutAsJsonAsync("edit-document", documentEditData);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Изменения успешно применены!");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка изменения документа!");
                    }

                    changeDocument = false;
                }
                else
                {
                    MessageBox.Show("Выберите хотя бы одну категорию документа!");
                }
            }
        }

        private async void ManageDocumentForm_Load(object sender, EventArgs e)
        {
            CategoriesCLB.Items.Clear();

            if (this.Text == "Добавление документа" && this.AddApply.Text == "Добавить")
            {
                DocumentNameTB.Text = name;
                ExtensionLabel.Text = ext;
                DocumentPathTB.Text = path;

                RTB.Text = await documentReader.DocumentFormatReading(name + ext, path);

                label2.Visible = true;
                DocumentPathTB.Visible = true;
                DocumentNameTB.ReadOnly = true;
                DocumentPathTB.ReadOnly = true;
                RTB.ReadOnly = true;
            }

            await boxFiller.GetCategories(CategoriesCLB, "get-other-categories");

            if (this.Text == "Редактирование документа" && this.AddApply.Text == "Применить изменения")
            {
                DocumentNameTB.ReadOnly = false;
                label2.Visible = false;
                DocumentPathTB.Visible = false;
                RTB.ReadOnly = false;

                DocumentNameTB.Text = name;
                ExtensionLabel.Text = ext;

                await boxFiller.SetCheckedCategories(CategoriesCLB, $"get-checked-categories/{name + ext}");

                await boxFiller.GetDocumentContent(name + ext, RTB);
            }

            changeDocument = false;
        }

        private void ManageDocumentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Text == "Редактирование документа" && this.AddApply.Text == "Применить изменения")
            {
                if (changeDocument == true)
                {
                    closingEditer.WarningMessage(e);
                }
            }
        }

        private void DocumentNameTB_TextChanged(object sender, EventArgs e)
        {
            changeDocument = true;
        }

        private void RTB_TextChanged(object sender, EventArgs e)
        {
            changeDocument = true;
        }

        private void CategoriesCLB_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            changeDocument = true;
        }
    }
}
