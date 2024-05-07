$(document).ready(function () {

    var mode=$("#mode").val();
    var isvalid = true;
    var selectedCountryId;
    var selectedcityId;

    


    //firstName
    $(Globalvariable.firsname).on("input", function ()
    {
        var fname = $(Globalvariable.firsname).val();
        console.log(fname);

        var regex_name = /^(?! )[a-zA-Z]+$/;
        if (fname == '') {
            $(Globalvariable.fnameerror).text('Please provide a First Name').show();
            $(Globalvariable.fnameicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        else if (!regex_name.test(fname))
        {
            $(Globalvariable.fnameerror).text('Please provide a alphabetics only').show();
            $(Globalvariable.fnameicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        else {
            $(Globalvariable.fnameerror).text('Please provide a First Name').hide();
            $(Globalvariable.fnameicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
            isvalid = true;
            return true;
        }

    });

//LastName

    $(Globalvariable.lastname).on("input", function () {
        var lname = $(Globalvariable.lastname).val();
        console.log(lname);
        var regex_name = /^(?! )[a-zA-Z]+$/;
        if (lname == '') {
            $(Globalvariable.lnameerror).text('Please provide a Last Name').show();
            $(Globalvariable.lnameicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        else if (!regex_name.test(lname)) {
            $(Globalvariable.lnameerror).text('Please provide alphabetics a Last Name').show();
            $(Globalvariable.lnameicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        else
        {
            $(Globalvariable.lnameerror).text('Please provide a Last Name').hide();
            $(Globalvariable.lnameicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
            isvalid = true;
            return true;
        }

    });

    //Department
    $(Globalvariable.department).on("input", function () {
        var department = $("#inputdepartment").val();
        console.log(department);

        if (department == '') {
            $(Globalvariable.departmenterror).text('Please provide Department').show();
            $(Globalvariable.departmenticon).html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        else {
            $(Globalvariable.departmenterror).text('Please provide Department').hide();
            $(Globalvariable.departmenticon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
            isvalid = true;
            return true;
        }

    });

    //phone validation
    $(Globalvariable.phone).on("input", function ()
    {
        var phoneinput = $("#inputphone").val();
        console.log(phoneinput);

        //var regex = /^(\+\d{1,3}[- ]?)?[6-9]\d{9}$/;
        var regex = /^(?:\+91[- ]?)?[6-9]\d{9}$/
        if (phoneinput == '') {
            $("#phoneerror").text('Please provide a Mobile Number').show();
            $(Globalvariable.phoneicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        else if (!regex.test(phoneinput))
        {
            $("#phoneerror").text('Please provide valid mobile number').show();
            $(Globalvariable.phoneicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        else {
            $("#phoneerror").text('Please provide 10 Digit Mobile Number').hide();
            $(Globalvariable.phoneicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
            isvalid = true;
            return true;
        }

    });

    //date validation
    $(Globalvariable.date).on("input", function () {

        var date = $(Globalvariable.date).val();
        console.log(date);
        if (date == '') {
            $(Globalvariable.dateerror).text('Please provide a Date').show();
            $(Globalvariable.dateicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        else {
            $(Globalvariable.dateerror).text('Please provide a Date').hide();
            $(Globalvariable.dateicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
            isvalid = true;
            return true;
        }
    });


    //time validation
    $(Globalvariable.time).on("input", function ()
    {

        var timeinput = $(Globalvariable.time).val();
        console.log(timeinput);
        if (timeinput == '') {
            $(Globalvariable.timeerror).text('Please provide a Time').show();
            $(Globalvariable.timeicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
            isvalid = false;
            return false;
        }
        else {
            $(Globalvariable.timeerror).text('Please provide a Time').hide();
            $(Globalvariable.timeicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
            isvalid = true;
            return true;
        }
    });

    //checkbox validation

    $('.status-item input[type="checkbox"]').on("change", function ()
    {
        var status = $('status-item input[type = "checkbox"]:checked');

        if ($(Globalvariable.StaffCheckbox).prop("checked")) {
            status += 'Staff,';

        }

        if ($(Globalvariable.managementcheckbox).prop("checked")) {
            status += 'Management,';
        }

        if ($(Globalvariable.OtherCheckbox).prop("checked")) {
            status += 'Other,';
        }
        status = status.replace(/,$/, '');

        if (status === '') {
            $("#statuserror").text('Please select  any one status').show();
            $(Globalvariable.statusicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
        }
        else if (status.indexOf(',') !== -1) 
        {
            $(Globalvariable.statuserror).text('Please select  only one status').show();
            $(Globalvariable.statusicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
        }
        else
        {
            $(Globalvariable.statuserror).text('Please select  any one status').hide();
            $(Globalvariable.statusicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
        }
    })



    


    var selectedcountryName
    $(Globalvariable.countryIdvariable).on("change", function ()
    {
        $(Globalvariable.cityIdvariable).empty();
        selectedCountryId = parseInt($(Globalvariable.countryIdvariable).val(),0);
        console.log(selectedCountryId);
        $.get("/HRForm/GetCities", { CountryId: selectedCountryId }, function (data) {
            $(Globalvariable.cityIdvariable).append("<option value=''>Select City</option>")
            $.each(data, function (index, row) {

                $(Globalvariable.cityIdvariable).append("<option value='" + row.cityId + "'>" + row.cityName + "</option>")
            })


            selectedcountryName = $("#CountryId option:selected").text();
            $("#selectedCountryName").text(selectedcountryName);
        });
    });

    var selectedCityName;

    $(Globalvariable.cityIdvariable).on("change", function ()
    {
        
        selectedcityId = parseInt($(Globalvariable.cityIdvariable).val(), 10);
        selectedCityName = $(this).find("option:selected").text();


        console.log('selectedcityId', selectedcityId);
    });


    //country and city validation 
    $(Globalvariable.cityIdvariable).on("click", function () {
        var cityinputval = $(Globalvariable.cityIdvariable).val()
        if (cityinputval === '') {
            $("#citydropdownlisterror").text('Please select Country Dropdownlist First').show();
            $(Globalvariable.cityicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
        }
        else {
            $("#citydropdownlisterror").text('Please select Country Dropdownlist First').hide();
            $(Globalvariable.cityicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
        }
    })

    $(Globalvariable.cityIdvariable).on("click", function () {
        var countryinputval = $(Globalvariable.countryIdvariable).val()
        if (countryinputval === '') {
            $(Globalvariable.countrydropdownerror).text('Please select Country Dropdownlist').show();
            $(Globalvariable.countryicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
        }
        else {
            $(Globalvariable.countrydropdownerror).text('Please select Country Dropdownlist').hide();
            $(Globalvariable.countryicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
        }
    })






        $(Globalvariable.btnupload).on("click", function () {


            var fname = $(Globalvariable.firsname).val();
            if (fname == '') {
                $(Globalvariable.fnameerror).text('Please provide a First Name').show();
                $(Globalvariable.fnameicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
                isvalid = false;

            }

            //LastName
            var lname = $(Globalvariable.lastname).val();
            if (lname == '') {
                $(Globalvariable.lnameerror).text('Please provide a Last Name').show();
                $(Globalvariable.lnameicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
                isvalid = false;

            }

            //Department
            var department = $(Globalvariable.department).val();
            if (department == '') {
                $(Globalvariable.departmenterror).text('Please provide Department').show();
                $(Globalvariable.departmenticon).html('<i class="fas  fa-exclamation-circle"></i>').show();
                isvalid = false;

            }

            //phone validation
            var phone = $(Globalvariable.phone).val();
            if (phone == '')
            {
                $(Globalvariable.phoneerror).text('Please provide a Mobile Number').show();
                $(Globalvariable.phoneicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
                isvalid = false;

            }
            else if (phone.length !== 10)
            {
                $(Globalvariable.phoneerror).text('Please provide 10 Digit Mobile Number').show();
                $(Globalvariable.phoneicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
                isvalid = false;

            }

            //date validation
            var date = $(Globalvariable.date).val();
            if (date == '') {
                $(Globalvariable.dateerror).text('Please provide a Date').show();
                $(Globalvariable.dateicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
                isvalid = false;

            }

            //time validation
            var time = $(Globalvariable.time).val();
            if (time == '') {
                $(Globalvariable.timeerror).text('Please provide a Time').show();
                $(Globalvariable.timeicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
                isvalid = false;
            }


            var countryinputval = $(Globalvariable.countryIdvariable).val();
            if (countryinputval === '') {
                $(Globalvariable.countrydropdownerror).text('Please select Country Dropdownlist ').show();
                $(Globalvariable.countryicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
            }
            else {
                $(Globalvariable.countrydropdownerror).text('Please select Country Dropdownlist ').hide();
                $(Globalvariable.countryicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
            }

            var cityinputval = $(Globalvariable.cityIdvariable).val();
            if (cityinputval === '') {
                $(Globalvariable.citydropdownerror).text('Please select city Dropdownlist ').show();
                $(Globalvariable.cityicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
            }
            else {
                $(Globalvariable.citydropdownerror).text('Please select city Dropdownlist ').hide();
                $(Globalvariable.cityicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
            }

           


            var status = '';

            if ($(Globalvariable.StaffCheckbox).prop("checked"))
            {
                status += 'Staff,';
            }

            if ($(Globalvariable.managementcheckbox).prop("checked")) {
                status += 'Management,';
            }

            if ($(Globalvariable.OtherCheckbox).prop("checked")) {
                status += 'Other,';
            }
            status = status.replace(/,$/, '');

            if (status === '') {
                $(Globalvariable.statuserror).text('Please select  any one status').show();
                $(Globalvariable.statusicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
          
                isvalid = false;

            }
            else if (status.indexOf(',') !== -1) {
                $(Globalvariable.statuserror).text('Please select  only one status').show();
                $(Globalvariable.statusicon).html('<i class="fas  fa-exclamation-circle"></i>').show();
                isvalid = false;

            }
            else {
                $(Globalvariable.statuserror).text('Please select any one status').hide();
                $(Globalvariable.statusicon).html('<i class="fas  fa-exclamation-circle"></i>').hide();
              
            }
           


            var formData = {
                FirstName: $(Globalvariable.firsname).val(),
                LastName: $(Globalvariable.lastname).val(),
                Department: $(Globalvariable.department).val(),
                Phone: $(Globalvariable.phone).val(),
                DateofIncident: $(Globalvariable.date).val(),
                TimeofIncident: $(Globalvariable.time).val(),
                IncidentLocation: $(Globalvariable.inputlocation).val(),
                Pleasespecifyincidentdetails: $(Globalvariable.incidenttextarea).val(),
                Witnessifavailable: $(Globalvariable.withnesstextarea).val(),
                Suggestions: $(Globalvariable.suggestionstextarea).val(),
                AdditionalComments: $(Globalvariable.additionalcomments).val(),
                Status: status,
                IsDeleted:true,

                cityId: parseInt($("#CityId").val(),0),
                CountryId: parseInt($("#CountryId").val(),0) 
                
            };

            mode = $("#mode").val();

            if (isvalid)
            {
                if (mode === 'submit') {
                    $.ajax({
                        url: "/HRForm/FormBooking",
                        type: 'POST',
                        data: formData,
                        success: function (data) {
                            if (data != null) {
                                alert('Form uploaded successfully');
                                window.location.href = '/HRForm/GetFormBookingList';
                            } else {
                                alert('File uploaded error');
                            }
                        },
                        error: function (xhr, status, error) {
                            console.error("Error", error);
                            console.error("Status", status);
                        }
                    });
                }

                else if (mode === 'Update') {

                    var id = $("#itemId").val();

                    $.ajax({
                        url: "/HRForm/HRFormUpdate",
                        type: 'POST',
                        data: { id: id, model: formData },
                        success: function (data) {
                            if (data != null) {
                                alert('Form ' + id + ' updated successfully');
                                window.location.href = '/HRForm/GetFormBookingList';
                            } else {
                                alert('File uploaded error');
                            }
                        },
                        error: function (xhr, status, error) {
                            console.error("Error", error);
                            console.error("Error", status);
                            alert('An error occurred during the form ' + id +'update');
                        }
                    });

                }
            }
        });
   

});









var Globalvariable = {

    btnupload: "#btn-submit",
    firsname: "#inputfirstname",
    lastname: "#inputlastname",
    department: "#inputdepartment",
    phone: "#inputphone",
    date:"#inputdate",
    time: "#inputtime",
    inputlocation: "#inputlocationtextarea",
    incidenttextarea: "#incidenttextarea",
    withnesstextarea: "#avalibletextarea",
    suggestionstextarea: "#inputsuggestion",
    additionalcomments: "#inputcomment",

    StaffCheckbox: "#staffCheckbox",
    managementcheckbox: "#managementCheckbox",
    OtherCheckbox: "#otherCheckbox", 

    submitbutton: "#btn-submit",
    countryIdvariable: "#CountryId",
    cityIdvariable: "#CityId",
    fnameerror: "#fnameerror",
    fnameicon: "#fnameicon",
    lnameerror: "#lnameerror",
    lnameicon: "#lnameicon",
    departmenterror:"#departmenterror",
    departmenticon: "#departmenticon",
    phoneerror: "#phoneerror",
    phoneicon:"#phoneicon",
    dateerror: "#dateerror",
    dateicon: "#dateicon", 
    timeerror:"#timeerror",
    timeicon: "#timeicon",
    statuserror: "#statuserror",
    statusicon:"#statusicon",
    countrydropdownerror: "#countrydropdownlisterror",
    citydropdownerror: "#citydropdownlisterror",
    countryicon: "#countryicon",
    cityicon:"#cityicon"
};
