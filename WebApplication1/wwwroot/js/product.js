
$(document).ready(function () {
    loadDataTable();
});

function deleteProduct(id) {
    fetch(`/Admin/Product/Delete?id=${id}`, {
        method: 'DELETE',
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            if (data.success) {
                // Handle success (e.g., refresh the table or show a success message)
                alert(data.message);
                location.reload(); // Simple way to refresh the page
            } else {
                // Handle failure
                alert("Error occurred while trying to delete the product.");
            }
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}


function loadDataTable() {

    dataTable = $('#tbData').DataTable({
        "ajax": { url: '/Admin/Product/getall' },
        "columns": [
            { data: "title","width":"10%" },
            { data: "description", "width": "20%" },
            { data: "isbn", "width": "15%" },
            { data: "author", "width": "15%" },
            { data: "category.name", "width": "15%" },
            {
                data: 'id',
                "width": "15%",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                <a href="/Admin/Product/Create?Id=${data}" class="btn btn-primary mx-2">Edit</a>
                <button class="btn btn-danger mx-2" onclick="deleteProduct(${data})">Delete</button>
            </div>`;
                }


            }
        ]
    });
}