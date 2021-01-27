
    window.dataLayer = window.dataLayer || [];
    function gtag() { dataLayer.push(arguments); }
    gtag('js', new Date());

    gtag('config', 'UA-23581568-13');
    function openCity(evt, cityName) {

        var i, tabcontent, tablinks;
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        tablinks = document.getElementsByClassName("tablinks");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace(" active", "");
        }
        document.getElementById(cityName).style.display = "block";
        evt.currentTarget.className += " active";

    }

    // Get the element with id="defaultOpen" and click on it
    document.getElementById("defaultOpen").click();

    
        var droppedFiles = false;
        var fileName = '';
        var $dropzone = $('.dropzone');
        var $button = $('.upload-btn');
        var uploading = false;
        var $syncing = $('.syncing');
        var $done = $('.done');
        var $bar = $('.bar');
        var timeOut;

    $dropzone.on('drag dragstart dragend dragover dragenter dragleave drop', function (e) {
        e.preventDefault();
        e.stopPropagation();
    })
        .on('dragover dragenter', function () {
            $dropzone.addClass('is-dragover');
        })
        .on('dragleave dragend drop', function () {
            $dropzone.removeClass('is-dragover');
        })
        .on('drop', function (e) {
            droppedFiles = e.originalEvent.dataTransfer.files;
            fileName = droppedFiles[0]['name'];
            $('.filename').html(fileName);
            $('.dropzone .upload').hide();
        });

    $button.bind('click', function () {
        startUpload();
    });

    $("input[name='file']").change(function () {
        fileName = $(this)[0].files[0].name;
        $('.filename').html(fileName);
        $('.dropzone .upload').hide();
    });
   
    function startUpload() {
        if (!uploading && fileName != '') {
            uploading = true;
            $button.html('Uploading...');
            $dropzone.fadeOut();
            $syncing.addClass('active');
            $done.addClass('active');
            $bar.addClass('active');
            timeoutID = window.setTimeout(showDone, 3200);
        }
    }

    function mychangeJoin() {
        var a = $(this).parent().find(".JoinDate");
        var b = $(this).val();
        b = b.split(" ")[0];
        b = new Date(b);

        var month = b.getMonth() + 1;
        var year = b.getFullYear();

        var day = b.getDate();

        if (day < 10)
            day = "0" + day;
        if (month < 10)
            month = "0" + month;
        var date = year + "-" + month + "-" + day;

            
        a.val(date);
    }
    function mychangeEnd() {
        var a = $(this).parent().find(".EndDate");
        var b = $(this).val();
        b = b.split(" ")[0];
        b = new Date(b);

        var month = b.getMonth() + 1;
        var year = b.getFullYear();

        var day = b.getDate();

        if (day < 10)
            day = "0" + day;
        if (month < 10)
            month = "0" + month;
        var date = year + "-" + month + "-" + day;


        a.val(date);
    }
    function showDone() {
        $button.html('Done');
    }
    function newwin()
    {
        var first = $(".booking-form").length;
      
        if (first == 1)
        {
            var button = document.createElement("button");
            button.classList.add("btn");
            button.classList.add("btn-danger");
            button.classList.add("remove");
            button.append("Remove");
            button.setAttribute("type", "button");
            button.addEventListener("click", remove);
            $("#booking legend").append(button);
        

        }
        var a = $('.JoinDate').length;
        var divP = document.createElement("div");

        divP.classList.add("row");
      
        var filedset = document.createElement("fieldset");
        filedset.classList.add("booking-form");
      
        var legend = document.createElement("legend");
        legend.append("School");
        legend.classList.add("form-header");

        var button = document.createElement("button");
        button.classList.add("btn");
        button.classList.add("btn-danger");
        button.classList.add("remove");
        button.append("Remove");
        button.setAttribute("type", "button");
        button.addEventListener("click",remove);
        legend.append(button);
        filedset.append(legend);

        var divrA = document.createElement("div");
        divrA.classList.add("no-margin");
        divrA.classList.add("row");

        var divCA1 = document.createElement("div");
        divCA1.classList.add("col-md-6");

        var divFA1 = document.createElement("div");
        divFA1.classList.add("form-group");
        divFA1.classList.add("separator");

        var divSA1 = document.createElement("span");
        divSA1.classList.add("form-label");
        divSA1.append("Name_school");
        divFA1.append(divSA1);

        var inputA1 = document.createElement("input");
        inputA1.classList.add("form-control");
        inputA1.classList.add("name_school");
        inputA1.setAttribute("type", "text");
        inputA1.setAttribute("name", "[" + a + "].Name_school");
      
        divFA1.append(inputA1);
        divCA1.append(divFA1);

        var divCA2 = document.createElement("div");
        divCA2.classList.add("col-md-6");

        var divFA2 = document.createElement("div");
        divFA2.classList.add("form-group");
      

        var divSA2 = document.createElement("span");
        divSA2.classList.add("form-label");
        divSA2.append("Location");
        divFA2.append(divSA2);

        var inputA2 = document.createElement("input");
        inputA2.classList.add("form-control");
        inputA2.setAttribute("type", "text");
        divFA2.append(inputA2);
        divCA2.append(divFA2);
        divrA.append(divCA1);
        divrA.append(divCA2);
        filedset.append(divrA);
        divP.append(filedset);
        inputA2.classList.add("location");
        inputA2.setAttribute("name", "[" + a + "].Location");

          var divrA = document.createElement("div");
        divrA.classList.add("no-margin");
        divrA.classList.add("row");

        var divCA1 = document.createElement("div");
        divCA1.classList.add("col-md-6");

        var divFA1 = document.createElement("div");
        divFA1.classList.add("form-group");
        divFA1.classList.add("separator");

        var divSA1 = document.createElement("span");
        divSA1.classList.add("form-label");
        divSA1.append("JoinDate");
        divFA1.append(divSA1);

        var hiddenA1 = document.createElement("input");
        hiddenA1.classList.add("form-control");
        hiddenA1.classList.add("JoinDate");
        hiddenA1.setAttribute("type", "hidden");
       
     
        divFA1.append(hiddenA1);
        var inputA1 = document.createElement("input");
        inputA1.classList.add("form-control");
        inputA1.classList.add("chooseJoin");
        
        inputA1.setAttribute("type", "date");
        inputA1.setAttribute("name", "[" + a + "].JoinDate");

        inputA1.addEventListener("change",mychangeJoin);
        divFA1.append(inputA1);
        divCA1.append(divFA1);

        var divCA2 = document.createElement("div");
        divCA2.classList.add("col-md-6");

        var divFA2 = document.createElement("div");
        divFA2.classList.add("form-group");
      

        var divSA2 = document.createElement("span");
        divSA2.classList.add("form-label");
        divSA2.append("EndDate");
        divFA2.append(divSA2);
        var hiddenA2 = document.createElement("input");
        hiddenA2.classList.add("form-control");
        hiddenA2.classList.add("EndDate");
        hiddenA2.setAttribute("type", "hidden");
        divFA2.append(hiddenA2);
        var inputA2 = document.createElement("input");
        inputA2.classList.add("form-control");
        inputA2.setAttribute("type", "date");
        inputA2.setAttribute("name", "[" + a + "].EndDate");
        inputA2.addEventListener("change", mychangeEnd);
        divFA2.append(inputA2);
        divCA2.append(divFA2);
        divrA.append(divCA1);
        divrA.append(divCA2);
        var inputId = document.createElement("input");
        inputId.classList.add("form-control");
        inputId.setAttribute("type", "hidden");
    
        inputId.setAttribute("name", "[" + a + "].id");
       
        filedset.append(inputId);
        
        filedset.append(divrA);
        divP.append(filedset);
      
         $('#booking').append(divP);
      
     
    }
    function remove() {
        var a = $(this).parent().parent();
      
        a.remove();
        var last = $(".booking-form").length;
       
        if (last == 1) {
            var lastRemove = $(".remove");
            lastRemove.remove();
        }
        var count = 0;
        $('.name_school').each(function () {

            $(this).attr("name", "[" + count + "].Name_school")
            count++;
         
        });
        var count = 0;
        $('.location').each(function () {

            $(this).attr("name", "[" + count + "].Location")
            count++;
          
        });
        var count = 0;
        $('.JoinDate').each(function () {

            $(this).attr("name", "[" + count + "].JoinDate")
            count++;
         
        });
        var count = 0;
        $('.EndDate').each(function () {

            $(this).attr("name", "[" + count + "].EndDate")
            count++;
          
        });
    }

        $(document).ready(function () {
        $('#myModal').on('shown.bs.modal', function () {
            $("#updatePersonal").attr("action", "Career/ChangePass")
        });
        $('#myModal').on('hidden.bs.modal', function () {
           
                $("#updatePersonal").attr("action", "Career/EditProfile")
            });
        var valB = $('input[name="DateOfBirth"]').val();
        valB = valB.split(" ")[0];
        valB = new Date(valB);

        
        var monthB = valB.getMonth() + 1;
        var yearB = valB.getFullYear();

        var dayB = valB.getDate();
           if (dayB < 10)
                dayB = "0" + dayB;
            if (monthB < 10)
                monthB = "0" + monthB;
        var dateB = yearB + "-" + monthB + "-" + dayB;
        $('input[name="chooseDateOfBirth"]').val(dateB);
            
        $('input[name="chooseDateOfBirth"]').change(function () {
            $('input[name="DateOfBirth"]').val($(this).val());
        });
        $('.JoinDate').each(function () {
          
            var a = $(this).parent().find(".chooseJoin");
            var b = $(this).val();
          
            b = b.split(" ")[0];
            b = new Date(b);
         
            var month = b.getMonth() + 1;
            var year = b.getFullYear();

            var day = b.getDate();

            if (day < 10)
                day = "0" + day;
            if (month < 10)
                month = "0" + month;
            var date = year + "-" + month + "-" + day;
           
            a.val(date);
        })
        $('.EndDate').each(function () {

            var a = $(this).parent().find(".chooseEnd");
            var b = $(this).val();
          
            b = b.split(" ")[0];
            b = new Date(b);

            var month = b.getMonth() + 1;
            var year = b.getFullYear();

            var day = b.getDate();

            if (day < 10)
                day = "0" + day;
            if (month < 10)
                month = "0" + month;
            var date = year + "-" + month + "-" + day;

            a.val(date);
        })
        $('.chooseEnd').change(function () {

            var b = $(this).parent().find(".EndDate");
            b.val($(this).val());
        });
        $('.chooseJoin').change(function () {
         
            var b = $(this).parent().find(".JoinDate");
            b.val($(this).val());
        });
        $('.remove').click(function () {
            var a = $(this).parent().parent();
            var b = $("#booking");
            a.remove();
            var last = $(".booking-form").length;
           
            if (last == 1)
            {
                var lastRemove = $(".remove");
                lastRemove.remove();
            }
            var count = 0;
            $('.name_school').each(function () {

                $(this).attr("name", "[" + count + "].Name_school")
                count++;
               
            });
            var count = 0;
            $('.location').each(function () {

                $(this).attr("name", "[" + count + "].Location")
             
                count++;
               
            });
            var count = 0;
            $('.JoinDate').each(function () {

                $(this).attr("name", "[" + count + "].JoinDate")
             
                count++;
               
            });
            var count = 0;
            $('.EndDate').each(function () {

                $(this).attr("name", "[" + count + "].EndDate")
               
                count++;
              
            });
         
        });
        $('input[name="Gender[]"').change(function () {

            var atLeastOneIsChecked = $('input[name="Gender[]"]:checked');
            $('input[name="Gender').val(atLeastOneIsChecked.val());
         
        });
     
        $('input[name="checkbox"').change(function () {
          
            if ($(this).is(':checked')) {
                // Do something...
                $('.photo').removeClass('hidden');

                
            }
            else
            {
                $('.photo').addClass('hidden');
            }

        });
        $('input[name="checkboxResume"').change(function () {

            if ($(this).is(':checked')) {
                // Do something...
                $('.centerIndex').removeClass('hidden');


            }
            else {
                $('.centerIndex').addClass('hidden');
            }

        });
    });


