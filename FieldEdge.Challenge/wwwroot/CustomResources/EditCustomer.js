new Vue({
    el: '#divEditCustomer',
    name: 'EditCustomerVue',
    data: {
        Temp: 0,
        Title: 'Add New Customer',
        CustomerId: 0,
        isAllCompleted: false,
        firstName: '',
        InvalidfirstName: false,
        lastName: '',
        InvalidlastName: false,
        emailddress: '',
        InvalidEmail: false,
        phone: '',
        countryCode: '',
        balance: ''
    },
    methods: {
        setData: function (id) {
            if (this.Temp !== 0) {
                return;
            }
            this.CustomerId = id == null ? "0" : id;
            this.Title = this.CustomerId === "0"  ? 'Add New Customer' : 'Edit Customer';
            this.Temp = 1;
            if (this.CustomerId !== "0") {
                this.EditCustomer();
            }
        },
        PressAnyKey: function (event) {
            this.validateInput(event.target.id);
        },
        validateInput: function (target) {

            let me = this;
            me.InvalidfirstName = (target === 'all' || target === 'firstName') && me.firstName === '';
            me.InvalidlastName = (target === 'all' || target === 'lastName') && me.lastName === '';
            me.InvalidEmail = (target === 'all' || target === 'emailddress') && me.emailddress === '';

            me.isAllCompleted = !me.InvalidfirstName && !me.InvalidlastName && !me.InvalidEmail;
        },
        EditCustomer: async function () {
            let me = this;
            let result = await Ajax.Call('/Customer/GetCustomerById', { id: me.CustomerId });
            me.firstName = result.firstname;
            me.lastName = result.lastname;
            me.emailddress = result.email;
            me.phone = result.phoneNumber;
            me.countryCode = result.countryCode;
            me.balance = result.balance;
        },
        Save: async function () {
            let me = this;
            me.validateInput('all');
            if (me.isAllCompleted) {
                let result = await Ajax.Call('/Customer/EditCustomer', {
                    Id: me.CustomerId,
                    Firstname: me.firstName,
                    Lastname: me.lastName,
                    Email: me.emailddress,
                    PhoneNumber: me.phone,
                    CountryCode: me.countryCode,
                    Balance: me.balance
                }, 'POST'); 

                if (result) {
                    window.location = '/Customer/Customers';
                }
            }
          
        },
        CancelEdit: function () {
            window.location = '/Customer/Customers';
        },
    },
    mounted: function () {
    }
});