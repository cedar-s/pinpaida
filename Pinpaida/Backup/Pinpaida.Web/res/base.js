$(function() {
    //选择品牌隐藏域赋值
    $('#brandlist li').click(function(){
        $('#brand').val($(this).attr('data-id'));
        $('#brandon').html($(this).html());
        $('#brandlist').hide();
    });

    //鼠标HOVER
    $('.brand-sel').hover(function(){
        $('#brandlist').show();
    }, function(){
        $('#brandlist').hide();
    });

    //搜索
    $('#btnsearch').click(function(){
        var brand = $('#brand').val();
        var word = $('#word').val();
        if(word != ''){
            window.location.href = '/search?brand=brand&word='+ encodeURIComponent(word);    
        }
    });
});