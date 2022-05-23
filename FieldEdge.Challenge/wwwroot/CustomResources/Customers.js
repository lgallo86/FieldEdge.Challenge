new Vue({
    el: '#divCustomer',
    name: 'CustomerVue',
    data: {
        CustomerList: [],
        CurrentIndex: 0,
        CustomerId: 0,
        perPage: 8,
        currentPage: 1,
        rows: 1,
        messageDelete: 'Your customer were deleted.',
        dismissSecs: 5,
        dismissCountDown: 0,
        fields : [
            { key: 'id', label: 'Customer Id' },
            { key: 'firstname', label: 'First Name' },
            { key: 'lastname', label: 'Last Name' },
            { key: 'email', label: 'Email' },
            { key: 'phoneNumber', label: 'Phone Number' },
            { key: 'countryCode', label: 'Country Code' },
            { key: 'gender', label: 'Gender' },
            { key: 'balance', label: 'Balance', formatter: (value, key, item) => value.toLocaleString('en-us', { style: 'currency', currency: 'USD' }) },
            { key: 'edit', label: 'Edit' },
            { key: 'delete', label: 'Delete' }
        ]
        },
    methods: {
        GetCustomerList: async function () {
            let me = this;
            let data = await Ajax.Call('/Customer/GetCustomers');
            me.CustomerList = data;
            me.rows = data.length;
        },
        EditItem: async function (item) {
            let me = this;
            me.CustomerId = item.id;
            window.location = '/Customer/EditCustomers/' + me.CustomerId; 
        },
        countDownChanged(dismissCountDown) {
            this.dismissCountDown = dismissCountDown
        },
        showAlert() {
            this.dismissCountDown = this.dismissSecs
        },
        handleOk: async function () {
            let me = this;
            let result = await Ajax.Call('/Customer/DeleteCustomer', { id: me.CustomerId }, 'POST');

            if (result) {
                this.showAlert();
                me.GetCustomerList();
                me.CustomerId = 0;
            }
        },
        DeleteItem: function (item) {
            let me = this;
            me.CustomerId = item.id;
            this.$bvModal.show('modal_Delete');            
        },
        AddNew: function () {
            window.location = '/Customer/EditCustomers';
        }
    },
    mounted: function () {
        this.GetCustomerList();
    }
});