$(document).ready(function () {
});


function ReloadPage() {
    window.location.reload();
}
function AddFreight() {
    var freightDTO = new Object();
    freightDTO.FreightValue = $('#AddFreightValue').val();
    freightDTO.BigPalletNumber = $('#AddBigPalletNumber').val();
    freightDTO.SmallPalletNumber = $('#AddSmallPalletNumber').val();
    var requiredFields = ["FreightValue", "BigPalletNumber", "SmallPalletNumber"];
    var isValid = true;

    for (var i = 0; i < requiredFields.length; i++) {
        var fieldName = requiredFields[i];
        if (!freightDTO[fieldName]) {
            isValid = false;
            $('#Add' + fieldName).addClass("is-invalid");
        } else {
            $('#Add' + fieldName).removeClass("is-invalid");
        }
    }
    if (isValid) {
        $.ajax({
            url: "/Product/AddFreight",
            data: JSON.stringify(freightDTO),
            type: 'POST',
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            success: function (data) {
                if (data.isSuccess === true && data.errorMessages === null) {
                    alert("Navlun bilgileri eklendi.");
                    ReloadPage();
                }
                else {
                    alert("Navlun bilgileri eklenirken hata oluştu.");
                }
            },
            error: function (e) {
                var errorMessage = e.responseText.replace(/\[|\]|"/g, '')
                alert("Hata: " + errorMessage);
            }
        });
    } else {
        alert("Lütfen gerekli tüm alanları doldurunuz.");
    }

}
function GetFreight(id) {
    $.ajax({
        url: "/Product/GetFreight/" + id,
        type: 'GET',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#UpdateFreightId').val(response.id)
            $('#UpdateFreightValue').val(response.freightValue);
            $('#UpdateBigPalletNumber').val(response.bigPalletNumber);
            $('#UpdateSmallPalletNumber').val(response.smallPalletNumber);
        },
        Error: function (e) {
            alert("Hata: " + e.responseText);
        }
    });
}
function UpdateFreight() {
    var freightDTO = new Object();
    freightDTO.FreightId = $('#UpdateFreightId').val();
    freightDTO.FreightValue = $('#UpdateFreightValue').val();
    freightDTO.BigPalletNumber = $('#UpdateBigPalletNumber').val();
    freightDTO.SmallPalletNumber = $('#UpdateSmallPalletNumber').val();
    var requiredFields = ["FreightValue", "BigPalletNumber", "SmallPalletNumber"];
    var isValid = true;

    for (var i = 0; i < requiredFields.length; i++) {
        var fieldName = requiredFields[i];
        if (!freightDTO[fieldName]) {
            isValid = false;
            $('#Update' + fieldName).addClass("is-invalid");
        } else {
            $('#Update' + fieldName).removeClass("is-invalid");
        }
    }
    if (isValid) {
        $.ajax({
            url: "/Product/UpdateFreight",
            data: JSON.stringify(freightDTO),
            type: 'POST',
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            success: function (data) {
                if (data) {
                    alert("Navlun bilgisi güncellendi.");
                    ReloadPage();
                }
                else {
                    alert("Navlun bilgisi güncellenirken hata oluştu!");
                }
            },
            error: function (e) {
                var errorMessage = e.responseText.replace(/\[|\]|"/g, '')
                alert("Hata: " + errorMessage);
            }
        });
    } else {
        alert("Lütfen gerekli tüm alanları doldurunuz.");
    }
}
function AddProduct() {
    var productDTO = new Object();
    productDTO.ProductName = $('#AddProductName').val();
    productDTO.ProductDescription = $('#AddProductDescription').val();
    productDTO.BoxNetKg = $('#AddBoxNetKg').val();
    productDTO.PalletBoxCount = $('#AddPalletBoxCount').val();
    productDTO.Pallet = $('#AddPallet').val();
    productDTO.BagGr = $('#AddBagGr').val();
    productDTO.Price = $('#AddPrice').val();
    productDTO.OutRate = $('#AddOutRate').val();
    productDTO.LaborCost = $('#AddLaborCost').val();
    productDTO.BoxBrossKg = $('#AddBoxBrossKg').val();

    var requiredFields = ["ProductName", "ProductDescription", "BoxNetKg", "PalletBoxCount", "Pallet", "BagGr", "Price", "OutRate", "LaborCost", "BoxBrossKg"];
    var isValid = true;
    for (var i = 0; i < requiredFields.length; i++) {
        var fieldName = requiredFields[i];
        if (!productDTO[fieldName]) {
            isValid = false;
            $('#Add' + fieldName).addClass("is-invalid");
        } else {
            $('#Add' + fieldName).removeClass("is-invalid");
        }
    }
    if (isValid) {
        $.ajax({
            url: "/Product/ProductAdd",
            data: JSON.stringify(productDTO),
            type: 'POST',
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            success: function (data) {
                if (data.isSuccess === true && data.errorMessages === null) {
                    alert("Ürün eklendi.");
                    ReloadPage();
                }
                else {
                    alert("Ürün eklenirken hata oluştu.");
                }
            },
            error: function (e) {
                var errorMessage = e.responseText.replace(/\[|\]|"/g, '')
                alert("Hata: " + errorMessage);
            }
        });
    } else {
        alert("Lütfen gerekli tüm alanları doldurunuz.");
    }
}
function ConfirmDelete(id) {
    if (confirm("Silmek istediğinize emin misiniz?")) {
        DeleteProduct(id);
    }
}
function DeleteProduct(id) {
    $.ajax({
        url: "/Product/DeleteProduct",
        data: JSON.stringify(id),
        type: 'POST',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            if (result === true) {
                alert("Silme işlemi başarılı.");
                ReloadPage();
            }
            else {
                alert("Silme hatası!");
            }
        },
        Error: function (e) {
            alert("Error: " + e.responseText);
        }
    });
}
function GetProduct(id) {
    $.ajax({
        url: "/Product/GetProduct/" + id, // Pass 'id' as a query parameter
        type: 'GET',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#UpdateProductId').val(id);
            $('#UpdateProductName').val(response.productName);
            $('#UpdateProductDescription').val(response.productDescription);
            $('#UpdateBoxNetKg').val(response.boxNetKg);
            $('#UpdatePalletBoxCount').val(response.palletBoxCount);
            $('#UpdatePallet').val(response.pallet);
            $('#UpdateBagGr').val(response.bagGr);
            $('#UpdatePrice').val(response.price);
            $('#UpdateOutRate').val(response.outRate);
            $('#UpdateLaborCost').val(response.laborCost);
            $('#UpdateBoxBrossKg').val(response.boxBrossKg);
        },
        Error: function (e) {
            alert("Hata: " + e.responseText);
        }
    });
}
function UpdateProduct() {
    var productDTO = new Object();
    productDTO.ProductId = $('#UpdateProductId').val();
    productDTO.ProductName = $('#UpdateProductName').val();
    productDTO.ProductDescription = $('#UpdateProductDescription').val();
    productDTO.BoxNetKg = $('#UpdateBoxNetKg').val();
    productDTO.PalletBoxCount = $('#UpdatePalletBoxCount').val();
    productDTO.Pallet = $('#UpdatePallet').val();
    productDTO.BagGr = $('#UpdateBagGr').val();
    productDTO.Price = $('#UpdatePrice').val();
    productDTO.OutRate = $('#UpdateOutRate').val();
    productDTO.LaborCost = $('#UpdateLaborCost').val();
    productDTO.BoxBrossKg = $('#UpdateBoxBrossKg').val();

    var requiredFields = ["ProductName", "ProductDescription", "BoxNetKg", "PalletBoxCount", "Pallet", "BagGr", "Price", "OutRate", "LaborCost", "BoxBrossKg"];
    var isValid = true;
    for (var i = 0; i < requiredFields.length; i++) {
        var fieldName = requiredFields[i];
        if (!productDTO[fieldName]) {
            isValid = false;
            $('#Update' + fieldName).addClass("is-invalid");
        } else {
            $('#Update' + fieldName).removeClass("is-invalid");
        }
    }
    if (isValid) {
        $.ajax({
            url: "/Product/UpdateProduct",
            data: JSON.stringify(productDTO),
            type: 'POST',
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            success: function (data) {
                if (data) {
                    alert("Ürün güncellendi.");
                    ReloadPage();
                }
                else {
                    alert("Ürün güncellenirken hata oluştu!");
                }
            },
            error: function (e) {
                var errorMessage = e.responseText.replace(/\[|\]|"/g, '')
                alert("Hata: " + errorMessage);
            }
        });
    } else {
        alert("Lütfen gerekli tüm alanları doldurunuz.");
    }
}
function GetProductPrice(id) {
    $.ajax({
        url: "/Product/GetProduct/" + id, // Pass 'id' as a query parameter
        type: 'GET',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            $('#UpdateProductPriceProductId').val(id);
            $('#UpdateProductPriceProductName').val(response.productName);
            $('#UpdateProductPriceDescription').val(response.productDescription);            
            $('#UpdateProductPricePrice').val(response.price);
            $('#UpdateProductPriceOutRate').val(response.outRate);

        },
        Error: function (e) {
            alert("Hata: " + e.responseText);
        }
    });
}
function UpdateProductPrices() {
    var updateProductPricesDTO = new Object();
    updateProductPricesDTO.ProductId = $('#UpdateProductPriceProductId').val();
    updateProductPricesDTO.ProductName = $('#UpdateProductPriceProductName').val();
    updateProductPricesDTO.ProductDescription = $('#UpdateProductPriceDescription').val();
    updateProductPricesDTO.Price = $('#UpdateProductPricePrice').val();
    updateProductPricesDTO.OutRate = $('#UpdateProductPriceOutRate').val();
    
    var requiredFields = ["Price", "OutRate"];
    var isValid = true;
    for (var i = 0; i < requiredFields.length; i++) {
        var fieldName = requiredFields[i];
        if (!updateProductPricesDTO[fieldName]) {
            isValid = false;
            $('#UpdateProductPrice' + fieldName).addClass("is-invalid");
        } else {
            $('#UpdateProductPrice' + fieldName).removeClass("is-invalid");
        }
    }
    if (isValid) {
        $.ajax({
            url: "/Product/UpdateProductPrices",
            data: JSON.stringify(updateProductPricesDTO),
            type: 'POST',
            contentType: 'application/json;charset=utf-8',
            dataType: 'json',
            success: function (data) {
                if (data) {
                    alert("Ürün güncellendi.");
                    ReloadPage();
                }
                else {
                    alert("Ürün güncellenirken hata oluştu!");
                }
            },
            error: function (e) {
                var errorMessage = e.responseText.replace(/\[|\]|"/g, '')
                alert("Hata: " + errorMessage);
            }
        });
    } else {
        alert("Lütfen gerekli tüm alanları doldurunuz.");
    }

}
