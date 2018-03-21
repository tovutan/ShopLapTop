$.fn.megamenu=function(e)
{
	function r()
	{
	 $(".megamenu").find("li, a").unbind(); // loại bỏ hết sự kiện trên thẻ li,a
	  if(window.innerWidth<=768)// nếu trình duyệt có độ rộng <=768
	  { 
			o();s();
			if(n==0)
			{
						$(".megamenu > li:not(.showhide)").hide(0) 
						// ẩn hết các thẻ li trong megamenu ngoại trừ thẻ .showhide
			}
	  }
	  else{u();i()}
	}
	function i()
	{
		$(".megamenu li").bind("mouseover",function()
			{
				$(this).children(".dropdown, .megapanel").stop().fadeIn(t.interval)
			})
		.bind("mouseleave",function(){$(this).children(".dropdown, .megapanel").stop().fadeOut(t.interval)})
	}
	function s()
	{
	   $(".megamenu > li > a").bind("click",function(e)
			{
			   if($(this).siblings(".dropdown, .megapanel").css("display")=="none")
			   // if($(".megamenu >li >a").siblings(".dropdown, .megapanel").css("display")=="none")
				{
					// $(this).siblings(".dropdown, .megapanel").slideDown(t.interval);
					$(this).siblings(".dropdown, .megapanel").slideDown(250);
					$(this).siblings(".dropdown").find("ul").slideDown(t.interval);
					n=1;
				}
				else
				{
					$(this).siblings(".dropdown, .megapanel").slideUp(t.interval);
					// nếu là khác display:none thì trượt lên
				}
			})
	}
	function o()
	{
		$(".megamenu > li.showhide").show(0);// hiện .showhide 
		$(".megamenu > li.showhide").bind("click",function()
		{
				if($(".megamenu > li").is(":hidden"))
				// nếu có thành phần nào không hiển thị(tức display:none; tức là thẻ li .showhide style="display:none;")
					{
						$(".megamenu > li").slideDown(300) 
						// trượt xuống nếu thành phần click vào là thẻ li.showhide style="display:none;"

					}
				else
				{
					$(".megamenu > li:not(.showhide)").slideUp(300); // trượt lên
					$(".megamenu > li.showhide").show(0) // đồng thời hiện thẻ showhide ra
				}
		})
	}
	function u()
	{
		$(".megamenu > li").show(0);
		$(".megamenu > li.showhide").hide(0)
	}
	var t={interval:250};
	var n=0;
	$(".megamenu").prepend("<li class='showhide'><span class='title'>MENU</span><span class='icon1'></span><span class='icon2'></span></li>");
	r();
	$(window).resize(function(){r()})
}