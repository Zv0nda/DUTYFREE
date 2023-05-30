function deleteProduct() {
	const id = $(this).data('id');
	var row = $(this).closest('tr');
	$.ajax({
		url: '/Products/Delete',
		method: "DELETE",
		data: { id: id },
		success: () => {
			row.remove(); // handle success
			$('.toast').toast();

		},
		error: (error) => {
			console.log(error);
		}
	});
}

function insertProduct() {
    // Získání hodnot z formuláře
    let row = $(this).closest("tr");
    var name = row.find(".Nazev").val();
    console.log(name);
    var imageUrl = row.find(".Obrazek").val();
    var quantity = row.find(".Kvantita").val();
    var price = row.find(".Cena").val();
    let product = new FormData();
    product.append("Name", name);
    product.append("Image", imageUrl);
    product.append("Quantity", quantity);
    product.append("Price",price);

    // Odeslání dotazu Insert pomocí AJAX
    $.ajax({
        url: '/Products/Insert',
        type: 'POST',
        data: product,
        processData: false,
        contentType: false,
        success: function (response) {
            // Úspěšné vložení - aktualizace tabulky nebo jiná odezva
            console.log('Produkt byl úspěšně vložen.');
        },
        error: function (xhr, status, error) {
            // Chyba při vkládání - zpracování chybového stavu nebo zobrazení chybového hlášení
            console.error('Chyba při vkládání produktu: ' + error);
        }
    });
}