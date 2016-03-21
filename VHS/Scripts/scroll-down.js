"use strict";

$('a#arrow-down, a.scroll-down').on('click', function()
{  jQuery('#nav').hide();
   var the_id = $(this).attr("href");  
   $('html, body').animate(
   {  
      scrollTop:$(the_id).offset().top          
   }, 'slow');  
   return false;  
});  


  
