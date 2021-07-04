
//ENABLE SCRIPTS AFTER THE FULL PAGE IS RENDERED TO USER
$(document).ready(function ()
{
   
   


    //          //Enabling Datepicker Option to User
    $("#todaysDateId").datepicker(
       {
           showOn: "button",
           buttonImage: "Content/themes/base/minified/images/calendar_final.png",
           changeMonth: true,
           changeYear: true,
           dateFormat: 'mm/dd/yy'
       });
    //          //On Key-Down event of Textboxes Change Css Style To Highlight Filed-Up TextBoxes
    $("#traineeId").keyup(function () {
        $("#traineeId").css("opacity", "1");
        var $th = $(this);
        $th.val($th.val().replace(/[^a-zA-Z0-9]/g, function (str)
          {
            //alert('You typed " ' + str + ' ".\n\nPlease use only letters and numbers.');
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.warning('Please Avoid entering " ' + str + ' "\n\n Please input only letters and numbers For Trainee Id', {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
            
            return "";
        }));
    });
    $("#firstNameId").keydown(function () {
        $("#firstNameId").css("opacity", "1");
    });
    $("#lastNameId").keydown(function () {
        $("#lastNameId").css("opacity", "1");
    });
    $("#todaysDateId").change(function () {
        $("#todaysDateId").css("opacity", "1");
    });
    $("#startedAtId").change(function () {
        $("#startedAtId").css("opacity", "1");
    });
    $("#whereId").keydown(function () {
        $("#whereId").css("opacity", "1");
    });
    $("#jobNameId").keydown(function () {
        $("#jobNameId").css("opacity", "1");
    });
    $("#fromTimeId").keydown(function () {
        $("#fromTimeId").css("opacity", "1");
    });
    $("#untilTimeId").keydown(function () {
        $("#untilTimeId").css("opacity", "1");
    });
    $("#workDoneId").keydown(function () {
        $("#workDoneId").css("opacity", "1");
    });
    $("#workexpid").keydown(function () {
        $("#workexpid").css("opacity", "1");
    });
    $("#commentId").keydown(function () {
        $("#commentId").css("opacity", "1");
    });

    //          //On Button Submit The following Events will be Triggered according to Need
    $("#btn_submit").click(function () {

        //              //Geting the Supplied Values from User and Storing them In Local Variables For Validation Purpose 
        var traineeId = $("#traineeId").val();
        var fname = $("#firstNameId").val();
        var lname = $("#lastNameId").val();
        var registrationDate = $("#todaysDateId").val();
        var startedAt = $("#startedAtId").val();
        var where = $("#whereId").val();
        var jobName = $("#jobNameId").val();
        var arrivedAtJob = $("#fromTimeId").val();
        var workeduntill = $("#untilTimeId").val();
        var workDone = $("#workDoneId").val();
        var anotherJob = $("#workexpid").val();
        var ownerComments = $("#commentId").val();


        //              //All Validations are Performed Here

        //              //Checking if All the Fields are Filled Up By User
        if (traineeId == "" && fname == "" && lname == "" && where == "" && jobName == "") {
            //Showing the Validation Result in TOASTER 
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.error("Please Fill All Mandatory Fields ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }
            //              //Checking if the TraineeId Field is Filled Up By User[These are for generating exclusiv Error/Warning Messages]
        else if (traineeId == "") {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.error("Please Fill Trainee Id ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }
            //              //Checking if the Trainee Id Contains Numbers,Underscore,Characters (If Special Characters are Present Warning will Pop-Up)                    
        else if (traineeId != traineeId.match(/^\w+$/)) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.warning("Trainee Id Should Not Contain Special Characters ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }
            //                    // length check

        else if (traineeId.length > 10) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.warning("Trainee Id limit exceeded MAX 10 CHARACTERS ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }


            //              //Checking if the Name fields are Not Left Blank
        else if (fname == "" || lname == "") {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.error("Please Fill Full Name ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }

            //              //Checking if the Name(BOTH Fname and Lname )Contains Characters only (If Special Characters/Numbers are Present Warning will Pop-Up)                    
        else if (fname != fname.match(/^[a-zA-Z\s]+$/) || lname != lname.match(/^[a-zA-Z\s]+$/)) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.warning("Your name can contain only alphabets  ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }

            //                  // length check

        else if (fname.length > 30) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.warning("First Name limit exceeded MAX 30 CHARACTERS ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }

            // length check

        else if (lname.length > 30) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.warning("Last Name limit exceeded MAX 30 CHARACTERS ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }

            //              //Ensuring UserSelects One of the Values from the Available set of Values[--User has to change Please select to avoid Warning--]               
        else if (startedAt == "Please Select") {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.error("Please Choose Started At Field ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }

            //              //Validating Empty Field for Where Field in thre UI
        else if (where == "") {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.error("Please Fill Where Field ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }

            // length check

        else if (where.length > 30) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.warning("Where Field limit exceeded MAX 30 CHARACTERS ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }

            //              //Validating JobName Field in thre UI
        else if (jobName == "") {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.error("Please Fill Job Name ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }

            // length check

        else if (jobName.length > 30) {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.warning("Job Name Field limit exceeded MAX 30 CHARACTERS ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }

            //              //Validating TimeInput Field in thre UI
        else if (arrivedAtJob == "") {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.error("Please Fill Arrived At Job Time ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }

            //              //Validating TimeOut Field in thre UI
        else if (workeduntill == "") {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.error("Please Fill Worked Until Time ", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }

            //              //Validating WorkDone Field in thre UI
        else if (workDone == "") {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": true,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "3000",
                "hideDuration": "3000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.error("Please Fill Work Done Field", {
                "timeOut": "0",
                "extendedTImeout": "0"
            });
        }

            //              //This is Executed Only When the User Inputs values which Had Passed the Validations above
            //Coding for Accepting Values and using json Store it to Database
        else {
            var RegistrationForm = {};
            RegistrationForm.TraineeId = $("#traineeId").val();


            RegistrationForm.FirstName = $("#firstNameId").val();
            RegistrationForm.LastName = $("#lastNameId").val();
            RegistrationForm.RegistrationDate = $("#todaysDateId").val();

            RegistrationForm.StartedAt = $("#startedAtId").val();

            RegistrationForm.PlaceWhere = $("#whereId").val();
            RegistrationForm.JobName = $("#jobNameId").val();

            RegistrationForm.InTime = $("#fromTimeId").val();
            RegistrationForm.OutTime = $("#untilTimeId").val();

            //RegistrationForm.RegistrationDate = $("#todaysDateId").val();

            RegistrationForm.WorkDone = $("#workDoneId").val();
            RegistrationForm.IfExtraWorkDone = $("input[name=anotherJob]:checked").val();
            RegistrationForm.OtherComments = $("#commentId").val();

            var res = JSON.stringify(RegistrationForm);

           
            //                  //This call invokes the Api controller which performs the Insertion Operation
            $.ajax({
                url: "/api/TraineeAPI/MyFunction",
                type: "POST",
                dataType: "JSON",
                contentType: "application/JSON;charset=UTF-8",              
                data: res,
                success: function (data) {
                    alert("The Obtained Path " + data);
                    //alert(data + " Rows Inserted");
                    toastr.options = {
                        "closeButton": true,
                        "debug": false,
                        "newestOnTop": true,
                        "progressBar": false,
                        "positionClass": "toast-top-right",
                        "preventDuplicates": false,
                        "onclick": null,
                        "showDuration": "1000",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "extendedTimeOut": "1000",
                        "showEasing": "swing",
                        "hideEasing": "linear",
                        "showMethod": "fadeIn",
                        "hideMethod": "fadeOut"
                    }
                    toastr.info("Have a Good Day Trainee", "Thanks For Submitting Your Details");

                    toastr.success("Your Details Are Saved Successfully-on Submit"+data, {

                        "timeOut": "0",
                        "extendedTImeout": "0"

                    }

                    );

                    //                          //Reload the Page after 2500s
                    setTimeout(function () {
                        window.location.reload();
                    }, 2500);
                },
                error: function (response) {
                    //alert("Error Due to : " + response.responseText)
                    toastr.options = {
                        "closeButton": true,
                        "debug": false,
                        "newestOnTop": true,
                        "progressBar": false,
                        "positionClass": "toast-top-right",
                        "preventDuplicates": false,
                        "onclick": null,
                        "showDuration": "300",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "extendedTimeOut": "1000",
                        "showEasing": "swing",
                        "hideEasing": "linear",
                        "showMethod": "fadeIn",
                        "hideMethod": "fadeOut"
                    }
                    toastr.error("Trainee Id already taken -err "+response, {
                        "timeOut": "0",
                        "extendedTImeout": "0"
                    });
                },
                failure: function (response) {
                    alert("Failure Due to : " + response.responseText)
                    toastr.options = {
                        "closeButton": true,
                        "debug": false,
                        "newestOnTop": true,
                        "progressBar": false,
                        "positionClass": "toast-top-right",
                        "preventDuplicates": false,
                        "onclick": null,
                        "showDuration": "300",
                        "hideDuration": "1000",
                        "timeOut": "5000",
                        "extendedTimeOut": "1000",
                        "showEasing": "swing",
                        "hideEasing": "linear",
                        "showMethod": "fadeIn",
                        "hideMethod": "fadeOut"
                    }
                }
            });

        }
    });
    $("#File").change(function ()
    {
        var data = new FormData();

        var files = $("#File").get(0).files;

        // Add the uploaded image content to the form data collection
        if (files.length > 0)
        {
            data.append("UploadedImage", files[0]);
        }

        $.ajax({
            url: "/api/TraineeAPI/UploadFile",
            type: "POST",
            dataType: "JSON",
            contentType: false,
            processData: false,
            data: data,
            success: function (data) {
                //alert(data + " Rows Inserted");
                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "newestOnTop": true,
                    "progressBar": false,
                    "positionClass": "toast-top-right",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "1000",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                }
                toastr.info("Have a Good Day Trainee", "Thanks For Submitting Your Details");

                toastr.success("Your Details Are Saved Successfully"+data, {

                    "timeOut": "0",
                    "extendedTImeout": "0"

                }

                );

                //                          //Reload the Page after 2500s
                
            },
            error: function (response) {
                //alert("Error Due to : " + response.responseText)
                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "newestOnTop": true,
                    "progressBar": false,
                    "positionClass": "toast-top-right",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                }
                toastr.error("Its not coming "+response.responseText, {
                    "timeOut": "0",
                    "extendedTImeout": "0"
                });
            },
            failure: function (response) {
                alert("Failure Due to : " + response.responseText)
                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "newestOnTop": true,
                    "progressBar": false,
                    "positionClass": "toast-top-right",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                }
            }
        });
    });
    //$("#chooseFileId").change(function ()
    //{
    //    var res = $("#chooseFileId").val();
    //    alert("See this "+res);
    //})

   

});
