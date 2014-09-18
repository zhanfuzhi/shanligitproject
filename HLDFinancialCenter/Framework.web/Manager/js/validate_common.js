String.prototype.Trim = function() { 
var m = this.match(/^\s*(\S+(\s+\S+)*)\s*$/); 
return (m == null) ? "" : m[1]; 
}
//邮政编码，6位，数字
var _PostCode=/^[0-9]{6}$/;
function ValidatePostCode(id){
    
    var str=document.getElementById(id).value;
    if(str=='undifined'||str=='')
        return true;
    var rs = _PostCode.test(str.Trim());
    if(!rs){
        alert("输入的邮政编码格式不正确！");
    }
    return rs;
}
//电话
var _Telphone=/^[0-9]{4}-[0-9]{7}$/;
function ValidateTelphone(id){
    var str=document.getElementById(id).value;
    if(str=='undifined'||str=='')
        return true;
    var rs = _Telphone.test(str.Trim());
    if(!rs){
        alert("输入的联系电话格式不正确！");
    }
    return rs;
}
//传真
var _Fax=/^[0-9]{4}-[0-9]{7}$/;
function ValidateFax(id){
    var str=document.getElementById(id).value;
    if(str=='undifined'||str=='')
        return true;
    var rs = _Fax.test(str.Trim());
    if(!rs){
        alert("输入的传真格式不正确！");
    }
    return rs;
}