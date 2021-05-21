// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function apagar(id,controller) {
    if (confirm('Confirma a exclusão do registro?'))
        location.href = controller+'/Delete?id=' + id;
}