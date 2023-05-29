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

			//showToast('Product deleted successfully!', 'success');
		},
		error: (error) => {
			console.log(error);
			//showToast('An error occurred while deleting the product.', 'error');
		}
	});
}