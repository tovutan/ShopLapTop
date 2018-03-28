$(document).ready(function () {
    // click Comment
    // $('.Comment').on('click', function () {
    //$(window).onload(function () { })
    $('.Comment').show(function(){

        //var id = $(this).attr("data-id"); // lấy giá trị data-id trong thẻ <button>
        //var id = $('.Comment').attr('data-id');
        var id = $(this).attr('data-id');
        var allCommentsArea = $('<div>').addClass('allComments_' + id);

        // test thử check length textarea
        var value = $(".form-control").val().length;
        if (value > 3)
        {
            alert("Ok man!");
        }

        //this function that allow us to get all comments related to post id
        // hàm function để lấy những comment liên quan đến sản phẩm
        $.ajax({
            //type: 'GET',
            type:'GET',
            url: '@Url.Action("GetListComment", "Comments")',
            data: { MaSP: id },
            success: function (response) {
                // sau khi trả về thành công thì kiểm tra xem có class allComments nào tồn tại trước đó không
                // nếu có thì xóa đi để thêm dữ liệu 


                if ($('div').hasClass('allComments_' + id + ''))
                {
                    $('div [class=allComments_' + id + ']').remove();
                }

                allCommentsArea = $('<div>').addClass('allComments_' + id);
                allCommentsArea.html(response);
                //allCommentsArea.prependTo('#commentsBlock_' + id); //thêm vào bên trong thẻ #commentsBlock và ở vị trí đầu tiên.
                allCommentsArea.appendTo('#commentsBlock_' + id); // thêm vào bên trong thẻ #commentsBlock và ở vị trí cuối cùng.
            },  
            error: function (response) {
                alert('Sorry: Comments cannot be loaded!');
            }
        })

    });

    // Add New Comment
    // sự kiện khi bấm vào nút button class addcComment
    $('.addComment').on('click', function () {
        //var ProductID = $(this).attr('data-id');
        //var MaSP = $(".addComment").attr('data-id');

        var allCommentsArea = $('<div>').addClass('allComments_' + MaSP);
        var MaSP = $(this).attr('data-id');
        var Content = $("#comment_" + MaSP).val();
        var dateTimeNow = new Date();

        var model = {
            Content: Content,
            Datetime: dateTimeNow.toLocaleString()
        };
        $.ajax({
            type: "POST",
            url: '@Url.Action("AddComment", "Comments")',
            @*url: '@Url.RouteUrl(new { action="AddComment",controller="Comments"})',*@
            //url:'/Comments/AddComment',
            data: { model, MaSP},
                    success: function (response) {

                if ($('div').hasClass('allComments_' + MaSP + ''))
                {
                    $('div [class=allComments_' + MaSP + ']').remove();
                }
                      
                        allCommentsArea = $('<div>').addClass('allComments_' + MaSP);
                        allCommentsArea.html(response);
                        //allCommentsArea.prependTo('#commentsBlock_' + MaSP); // thêm vào thẻ #commentsBlock và thêm ở vị trí đầu tiên
                        allCommentsArea.appendTo("#commentsBlock_" + MaSP);
                        
                    },
            complete: function () {
                //$('#comment').val("");

                //$('#comment').val("");
                $("#comment_" + MaSP).val("");
                      
            },
            error: function () {
                alert("Sorry :Add Comment Error");
            }
        });
        // });
    });
    (window.jQuery);
    //jQuery("time.timeago").timeago();
});
$(document).ready(function () {
    $("#comment").focus();
    $('#comment').val("");
})