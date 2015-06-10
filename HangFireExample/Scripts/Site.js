       $(function () {
           var bufferWidget = $('#buffer');

           setInterval(function() {
               $.get(bufferWidget.data('url'), function(data) {
                   bufferWidget.html(data);
                   bufferWidget.scrollTop(bufferWidget[0].scrollHeight);
               });
           }, 1000);
       });