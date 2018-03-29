var product = {
    init: function () {
        product.registerEvents();
    },
    registerEvents: function () {

        $('.btn-images').off('click').on('click', function () {
            $('#imagesManange').modal('show');
            $("#hidProductID").val($(this).data('id'));
            product.loadImage();
        });
        // viết sự kiện để khi click vào nút chọn ảnh trong modal thì hiển Ckfinder lên 
        $("#btnChooseImages").off('click').on('click', function (e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function (url) {
                var html = '<div style="float:left;">' +
                    '<img src="' + url + '" width="100"/>'+
                    '<a href="#" class="btnDelimage"><i class="fa fa-times"></i></a>' +
                    '<input type="hidden" class="hidImage" value="'+url+'"/>'+
                    '</div>';


               // $('#imageList').append('<div style="float:left;"><img src="' + url + '" width="100"/><a href="#" class="btnDelimage"><i class="fa fa-times"></i></a></div>');
                // $('#imageList').addClass('div')
                $('#imageList').append(html);
                $(".btnDelimage").off('click').on('click', function (e) {
                    e.preventDefault();
                    $(this).parent().remove();
                });
            };
            finder.popup();
        });

        $("#btnSaveImages").off('click').on('click', function () {
            var images = [];
            var MaSP = $("#hidProductID").val();
            //$.each($("#imageList img"), function (i, item) {
            $.each($("#imageList .hidImage"), function (i, item) {
                // images.push($(item).prop('src'));
                images.push($(item).val());
            });

            $.ajax({

                url: '/Admin/Sanpham/SaveImages',
                data: {
                    MaSP:MaSP,
                    images:JSON.stringify(images)   
                },
                type:'POST',
                dataType: 'json',
                success: function (response) {
                    if (response.trangthai == true)
                    {
                        $('#imagesManange').modal('hide');
                        $("#imageList").html('');
                        alert("Save thành công");
                    }                  
                }
            });
        });
    },

    loadImage: function () {

        $.ajax({
            url: '/Admin/SanPham/LoadImages',
            type:'GET',
            data: {
                MaSP: $("#hidProductID").val()
            },
            dataType: "json",
            success: function (response) {              
                    var data = response.data;
                    var html = '';
                    $.each(data, function (i, item) {
                        html += '<div style="float:left;"><img src="' + item + '" width="100"/><a href="#" class="btnDelimage"><i class="fa fa-times"></i></a><input type="hidden" class="hidImage" value="' + item + '"/></div>';
                    });
                    $("#imageList").html(html);

                    $(".btnDelimage").off('click').on('click', function (e) {
                        e.preventDefault();
                        $(this).parent().remove();
                    });
                    //product.registerEvents();
                    //$("#btnSaveImages").off('click').on('click', function () {
                    //    $('#imagesManange').modal('hide');
                    //})
            }
        });
    }
}
product.init();