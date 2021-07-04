
        $(document).ready(function () {
                             $("#todaysDateId").datepicker(
                {
                    showOn: "button",
                    buttonImage: "Content/themes/base/minified/images/calendar_final.png",
                    changeMonth: true,
                    changeYear: true,
                    dateFormat: 'dd-mm-yy'
                });

            $("#todaysDateId").datepicker(
               {
                   showOn: "button",
                   buttonImage: "Content/themes/base/minified/images/calendar_final.png",
                   changeMonth: true,
                   changeYear: true,
                   dateFormat: 'dd-mm-yy'
               });


            $("#btn_submit").click(function () {
                var traineeId = $("#traineeId").val();
                var fname = $("#firstNameId").val();
                var lname = $("#lastNameId").val();
                var startedAt = $("#startedAtId").val();
                var where = $("#whereId").val();
                var jobName = $("#jobNameId").val();
                var arrivedAtJob = $("#fromTimeId").val();
                var workeduntill = $("#untilTimeId").val();
                var workDone = $("#workDoneId").val();
                var anotheJob = $("#workexpid").val();
                var ownerComments = $("#commentId").val();
                
                 


                if (traineeId == "")
                {
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
                else if (fname == "" || lname=="")
                {
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

                else if (startedAt == "") {
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
                    toastr.error("Please Fill Started At Field ", {
                        "timeOut": "0",
                        "extendedTImeout": "0"
                    });
                }

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

                else {
                    var RegistrationForm = {};
                    RegistrationForm.TraineeId = $("#traineeId").val();


                    RegistrationForm.FirstName = $("#firstNameId").val();
                    RegistrationForm.LastName = $("#lastNameId").val();
                    RegistrationForm.TodaysDate = $("#todaysDateId").val();

                    RegistrationForm.StartedAt = $("#startedAtId").val();
                    if (RegistrationForm.StartedAt == "Please Select") {
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
                        toastr.error("Please Select From The List ", {
                            "timeOut": "0",
                            "extendedTImeout": "0"                          
                        });
                        RegistrationForm.StartedAt = "";
                    }
                    else {
                        RegistrationForm.StartedAt = $("#startedAtId").val();
                    }

                    RegistrationForm.PlaceWhere = $("#whereId").val();
                    RegistrationForm.JobName = $("#jobNameId").val();

                    RegistrationForm.ArrivedAtJob = $("#fromTimeId").val();
                    RegistrationForm.WorkedUntil = $("#untilTimeId").val();

                    RegistrationForm.WorkDone = $("#workDoneId").val();
                    RegistrationForm.WorkExperience = $("input[name=anotherJob]:checked").val();
                    RegistrationForm.OtherComments = $("#commentId").val();

                    var res = JSON.stringify(RegistrationForm);

                    $.ajax({
                        url: "/api/traineeRegistrationApi/insertTraineeDetails",
                        type: "POST",
                        dataType: "JSON",
                        contentType: "application/JSON;charset=UTF-8",
                        data: res,
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
                                "showDuration": "300",
                                "hideDuration": "1000",
                                "timeOut": "5000",
                                "extendedTimeOut": "1000",
                                "showEasing": "swing",
                                "hideEasing": "linear",
                                "showMethod": "fadeIn",
                                "hideMethod": "fadeOut"
                            }
                            toastr.info("Have a Good Day Trainee", "Thanks For Submitting Your Details");
                            toastr.success("Your Details Are Saved Successfully", {

                                "timeOut": "0",
                                "extendedTImeout": "0"

                            }

                            );
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
                            toastr.error("Trainee Id already taken ", {
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
            });
        
    