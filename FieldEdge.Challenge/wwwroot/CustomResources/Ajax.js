var Ajax = {

    Call: function (url, param, httpMethod) {

        let method = httpMethod == undefined ? 'GET' : httpMethod;

        return new Promise((resolve, reject) => {

            $.ajax({
                type: method.toUpperCase(),
                url: url,
                data: param,
                async: true,
                cache: false,
                success: function (data) {
                    resolve(data);
                },
                error: function (xhr, status, error) {
                    console.log('xhr', xhr);
                    console.log('status', status);
                    console.log('error', error);
                    reject(error);
                }
            });
        });
    },
    GenerateDataTable: function (tableName) {
        let me = this;
        $("#" + tableName).DataTable().destroy();
        setTimeout(function () {
            me.fillJQueryDataTable(tableName);
            me.hideLoading();
        }, 500);
    }
}