$(document).ready(function () {
$(function () {
    $("#grid").jqGrid({
        url: "/ContractRenewals/Load",
        datatype: 'json',
        mtype: 'Get',
        colNames: [
            'Id', 'Business', 'Jul 16', 'Aug 16', 'Sep 16', 'Oct 16', 'Nov 16', 'Dec 16', 'Jun 17', 'Feb 17', 'Mar 17', 'Apr 17', 'May 17', 'Jun 17'
        ],
        colModel: [
            { key: true, hidden: true, name: 'Id', index: 'Id', editable: true },
            { key: false, name: 'Business', index: 'Business', editable: true, editrules: { custom: true, custom_func: Business} },
            { key: false, name: 'Column1', index: 'Column1', editable: true },
            { key: false, name: 'Column2', index: 'Column2', editable: true },
            { key: false, name: 'Column3', index: 'Column3', editable: true },
            { key: false, name: 'Column4', index: 'Column4', editable: true },
            { key: false, name: 'Column5', index: 'Column5', editable: true },
            { key: false, name: 'Column6', index: 'Column6', editable: true },
            { key: false, name: 'Column7', index: 'Column7', editable: true },
            { key: false, name: 'Column8', index: 'Column8', editable: true },
            { key: false, name: 'Column9', index: 'Column9', editable: true },
            { key: false, name: 'Column10', index: 'Column10', editable: true },
            { key: false, name: 'Column11', index: 'Column11', editable: true },
            { key: false, name: 'Column12', index: 'Column12', editable: true }
        ],
        pager: jQuery('#pager'),
        rowNum: 12,
        rowList: [10, 20, 30, 40],
        height: '220px',
        width: '20px',
        viewrecords: true,
        caption: 'Pending',
        emptyrecords: 'No records to display',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
    }).navGrid('#pager', { edit: true, add: true, del: true, search: false, refresh: true },
        {
            // edit options
            zIndex: 101,
            url: "/ContractRenewals/Edit",
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            // add options
            zIndex: 101,
            url: "/ContractRenewals/Create",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            // delete options
            zIndex: 101,
            url: "/ContractRenewals/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Are you sure you want to delete this task?",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        });
    });
    $('#grid').jqGrid('setGridWidth', '462');
    
});

function Business(value) {
    if (value == '') {
        return [false, 'Please enter Business', ''];
    }
    return [true, '', ''];
}