(function () {
    $(document).ready(function () {
        $('#btn-addProduct').on('click', addNewProduct);
        $('#btn-cancelProduct').on('click', hideProductForm);
        $('#btn-saveProduct').on('click', saveNewProduct);
        $('#btn-loadProducts').on('click', getProducts);
        $('#tbl-products').on('click', 'td span', deleteProduct);
        $('#error-close').on('click', hideError);
        getProducts();
    });

    function getProducts() {
        $.ajax({
            url: 'https://localhost:5001/api/product/getallproducts'
        })
            .done(function (result) {
                if (result != undefined && result != null) {
                    if (result.error != 1) {
                        if (result.data.length > 0) {
                            buildProductTable(result.data);
                        } else {
                            hideBlocks();
                            $('#blankstate').removeClass('hide');
                        }
                    } else {
                        hideBlocks();
                        $('#error-message').html(result.message);
                        $('#error-container').removeClass('hide');
                    }
                } else {
                    hideBlocks();
                    $('#error-message').html('No se obtubo una respuesta del servidor, intente nuevamente');
                    $('#error-container').removeClass('hide');
                }
            })
            .fail(function (error) {
                hideBlocks();
                $('#error-message').html(error.message);
                $('#error-container').removeClass('hide');
            });
    }

    function buildProductTable(data) {
        let htmlTbody = '';
        for (let index = 0; index < data.length; index++) {
            htmlTbody += buildProductLine(data[index])
        }
        hideBlocks();
        $('#tbl-products tbody').html(htmlTbody);
        $('#tbl-products').removeClass('hide');
    }

    function buildProductLine(data, newProduct = false) {
        const productClass = newProduct ? 'hide' : '';
        return `<tr class="${productClass}" data-id="${data.id}">
                    <td>${data.id}</td>
                    <td>${data.type}</td>
                    <td>${data.name}</td>
                    <td>${data.expiration}</td>
                    <td><span>Eliminar</span></td>
                </tr>`;
    }

    function addNewProduct() {
        hideBlocks(false);
        $('#form-container').removeClass('hide');
    }

    function hideBlocks(hideTable = true) {
        if (hideTable) {
            $('#blankstate, #error-container, #tbl-products, #form-container').addClass('hide');
        } else {
            $('#blankstate, #error-container, #form-container').addClass('hide');
        }
    }

    function saveNewProduct() {
        const _type = $('#txt-type').val();
        const _name = $('#txt-name').val();
        const _expiration = $('#txt-expiration').val();
        const productLine = buildProductLine({ type: _type, name: _name, expiration: _expiration }, true);
        $('#tbl-products tbody').append(productLine);
        $.ajax({
            url: 'https://localhost:5001/api/product/AddProduct',
            method: 'POST',
            contentType: 'application/json',
            data: {
                Id: 0,
                Type: _type,
                Name: _name,
                Expiration: _expiration
            }
        })
            .done(function (result) {
                if (result != undefined && result != null) {
                    if (result.error != 1) {
                        if (result.data > 0) {
                            $('#tbl-products tbody tr.hide td:first-child').html(result.data);
                            $('#tbl-products tbody tr.hide').removeClass('hide');
                        } else {
                            $('#tbl-products tbody tr.hide').remove();
                            $('#error-message').html('No se pudo agregar el producto, intente de nuevo.');
                            $('#error-container').removeClass('hide');
                        }
                    } else {
                        hideBlocks();
                        $('#error-message').html(result.message);
                        $('#error-container').removeClass('hide');
                    }
                } else {
                    hideBlocks();
                    $('#error-message').html('No se obtubo una respuesta del servidor, intente nuevamente');
                    $('#error-container').removeClass('hide');
                }
            })
            .fail(function (error) {
                hideBlocks();
                $('#error-message').html(error.message);
                $('#error-container').removeClass('hide');
            });
    }

    function deleteProduct() {
        const _id = $(this).parents('tr').attr('data-id');
        $.ajax({
            url: 'https://localhost:5001/api/Product/DeleteProduct',
            method: 'DELETE',
            contentType: 'application/json',
            data: {
                id: _id
            }
        })
            .done(function (result) {
                if (result != undefined && result != null) {
                    if (result.error != 1) {
                        $('#tbl-products tr[data-id="' + result.data + '"]').remove();
                    } else {
                        hideBlocks();
                        $('#error-message').html(result.message);
                        $('#error-container').removeClass('hide');
                    }
                } else {
                    hideBlocks();
                    $('#error-message').html('No se obtubo una respuesta del servidor, intente nuevamente');
                    $('#error-container').removeClass('hide');
                }
            })
            .fail(function (error) {
                hideBlocks();
                $('#error-message').html(error.message);
                $('#error-container').removeClass('hide');
            });
    }

    function hideError() {
        $('#error-container').addClass('hide');
    }

    function hideProductForm() {
        $('#form-container').addClass('hide');
    }
})();