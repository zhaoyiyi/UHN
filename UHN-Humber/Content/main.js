
$(document).ready(function(){



    $(".mobile-menu").click(function(){
        if($(".mobile_div").hasClass("closed")){
			$(".mobile_div").removeClass("closed");
		}
		else{
			$(".mobile_div").addClass("closed");
		}
    });

	$(".mobile_first_nav").click(function(){
		if($(this).hasClass("notopen")){
			$(".mobile_first_nav").addClass("notopen");
			$(".mobile_first_nav").removeClass("open");
			$(".mobile_first_nav").next().addClass("closed");
			$(this).removeClass("notopen");
			$(this).addClass("open");
			$(this).next().removeClass("closed");
		}
		else{
			$(".mobile_first_nav").addClass("notopen");
			$(".mobile_first_nav").removeClass("open");
			$(".mobile_first_nav").next().addClass("closed");
			$(this).addClass("notopen");
			$(this).removeClass("open");
			$(this).next().addClass("closed");
		}

	});





	$(window).resize(function(){
		 if ($(window).width() > 768) {
			 if($(".mobile_div").hasClass("closed")){
				 $(".mobile_first_nav").addClass("notopen");
				 $(".mobile_first_nav").removeClass("open");
				 $(".mobile_second_nav").addClass("closed");


			}
			else{
				$(".mobile_div").addClass("closed");
				$(".mobile_first_nav").addClass("notopen");
				 $(".mobile_first_nav").removeClass("open");
				  $(".mobile_second_nav").addClass("closed");

			}

		}

	});



});