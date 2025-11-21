using System.Collections.ObjectModel;
using ProductTable.Product;
using ProductBase = ProductTable.Product.Product;

namespace ProductTable;

public partial class MainPage : ContentPage
{
    private readonly ObservableCollection<ProductBase> _items = new();

    public MainPage()
    {
        InitializeComponent();
        ProductsView.ItemsSource = _items;
    }

    private void OnAddProductClicked(object sender, EventArgs e)
    {
        ClearDialogFields();
        AddDialog.IsVisible = true;
    }

    private void OnCancelAddClicked(object sender, EventArgs e)
    {
        AddDialog.IsVisible = false;
    }

    private void OnTypeChanged(object sender, EventArgs e)
    {
        if (TypePicker.SelectedIndex == 0)
        {
            BookFields.IsVisible = false;
            GroceriesFields.IsVisible = false;
            return;
        }

        var selected = TypePicker.Items[TypePicker.SelectedIndex];

        if (selected == "Книга")
        {
            BookFields.IsVisible = true;
            GroceriesFields.IsVisible = false;
        }
        else if (selected == "Продукт")
        {
            BookFields.IsVisible = false;
            GroceriesFields.IsVisible = true;
        }
    }

    private async void OnSaveProductClicked(object sender, EventArgs e)
    {
        if (TypePicker.SelectedIndex == 0)
        {
            await DisplayAlertAsync("Помилка", "Оберіть тип товару", "OK");
            return;
        }

        var name = NameEntry.Text;
        var priceText = PriceEntry.Text;
        var country = CountryEntry.Text;
        var description = DescriptionEntry.Text;

        if (string.IsNullOrWhiteSpace(name))
        {
            await DisplayAlertAsync("Помилка", "Поле \"Назва\" є обовʼязковим", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(priceText))
        {
            await DisplayAlertAsync("Помилка", "Поле \"Ціна\" є обовʼязковим", "OK");
            return;
        }

        if (!double.TryParse(priceText, out var price))
        {
            await DisplayAlertAsync("Помилка", "Невірний формат ціни", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(country))
        {
            await DisplayAlertAsync("Помилка", "Поле \"Країна\" є обовʼязковим", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            await DisplayAlertAsync("Помилка", "Поле \"Опис\" є обовʼязковим", "OK");
            return;
        }

        var type = TypePicker.Items[TypePicker.SelectedIndex];

        if (type == "Книга")
        {
            if (string.IsNullOrWhiteSpace(PagesEntry.Text))
            {
                await DisplayAlertAsync("Помилка", "Поле \"Кількість сторінок\" є обовʼязковим", "OK");
                return;
            }

            if (!int.TryParse(PagesEntry.Text, out var pages))
            {
                await DisplayAlertAsync("Помилка", "Невірна кількість сторінок", "OK");
                return;
            }

            var publishingHouse = PublishingHouseEntry.Text;
            if (string.IsNullOrWhiteSpace(publishingHouse))
            {
                await DisplayAlertAsync("Помилка", "Поле \"Видавництво\" є обовʼязковим", "OK");
                return;
            }

            var authorsRaw = AuthorsEntry.Text;
            if (string.IsNullOrWhiteSpace(authorsRaw))
            {
                await DisplayAlertAsync("Помилка", "Поле \"Автори\" є обовʼязковим", "OK");
                return;
            }

            var authors = new List<string>(
                authorsRaw.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries));

            if (authors.Count == 0)
            {
                await DisplayAlertAsync("Помилка", "Вкажіть хоча б одного автора", "OK");
                return;
            }

            var book = new Books(
                price: price,
                country: country.Trim(),
                name: name.Trim(),
                createdAt: DateTime.Now,
                description: description.Trim(),
                pagesAmount: pages,
                publishingHouse: publishingHouse.Trim(),
                authors: authors);

            _items.Add(book);
        }
        else if (type == "Продукт")
        {
            if (string.IsNullOrWhiteSpace(AmountEntry.Text))
            {
                await DisplayAlertAsync("Помилка", "Поле \"Кількість\" є обовʼязковим", "OK");
                return;
            }

            if (!int.TryParse(AmountEntry.Text, out var amount))
            {
                await DisplayAlertAsync("Помилка", "Невірна кількість", "OK");
                return;
            }

            var measurementUnit = MeasurementUnitEntry.Text;
            if (string.IsNullOrWhiteSpace(measurementUnit))
            {
                await DisplayAlertAsync("Помилка", "Поле \"Одиниця виміру\" є обовʼязковим", "OK");
                return;
            }

            var expiration = ExpirationDatePicker.Date ?? DateTime.Today;

            var grocery = new Groceries(
                price: price,
                country: country.Trim(),
                name: name.Trim(),
                createdAt: DateTime.Now,
                description: description.Trim(),
                expirationDate: expiration,
                amount: amount,
                measurementUnit: measurementUnit.Trim());

            _items.Add(grocery);
        }

        AddDialog.IsVisible = false;
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DeleteButton.IsEnabled = ProductsView.SelectedItem != null;
    }

    private async void OnDeleteProductClicked(object sender, EventArgs e)
    {
        if (ProductsView.SelectedItem is ProductBase selected)
        {
            bool confirm = await DisplayAlertAsync("Підтвердження",
                $"Видалити \"{selected.Name}\"?",
                "Так", "Ні");

            if (confirm)
            {
                _items.Remove(selected);
            }
        }
    }

    private void ClearDialogFields()
    {
        TypePicker.SelectedIndex = 0;
        BookFields.IsVisible = false;
        GroceriesFields.IsVisible = false;

        NameEntry.Text = string.Empty;
        PriceEntry.Text = string.Empty;
        CountryEntry.Text = string.Empty;
        DescriptionEntry.Text = string.Empty;

        PagesEntry.Text = string.Empty;
        PublishingHouseEntry.Text = string.Empty;
        AuthorsEntry.Text = string.Empty;

        AmountEntry.Text = string.Empty;
        MeasurementUnitEntry.Text = string.Empty;
        ExpirationDatePicker.Date = DateTime.Today;
    }
}
