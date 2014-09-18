<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Doc_Online.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Document.Doc_Online" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="在线证书编辑" HeadTitleTxt="在线证书编辑">
    </FrameWorkWebControls:HeadMenuWebControls>
        <table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0"
            bordercolordark="#ffffff">
            <%--<tr>
                <td height="22" background="../images/show_02.gif" align="left" style="font-size: 12px;
                    font-family: 宋体">
                    在线证书管理</td>
            </tr>--%>
            <tr>
                <td valign="top" style="text-align: center">
                    <table height="26" cellspacing="0" cellpadding="0" width="100%" border="0" >
                        <tr>
                            <td>
                                <div style="text-align:center;width:100%;margin-bottom:10px;">
                                
                                <asp:DropDownList ID="Doc_DropDown" runat="server" Width="115px">
                                    
                                </asp:DropDownList>
                                
                                <%--<asp:Button ID="SelectTemplate_Button" runat="server" Text="选择模板"
                                    onclick="SelectTemplate_Button_Click"/>
                                <input id="sss" onclick="javascript:FillData();" value="填入数据"  type="button"/>
                                
                                <input style="width: 100px" onclick="Track()" type="button" value="进入留痕" id="Button8"
                                    runat="server">
                                <input style="width: 100px" onclick="UnTrack()" type="button" value="取消留痕" id="Button9"
                                    runat="server">
                                <input style="width: 100px" onclick="clearTrack()" type="button" value="清除留痕" id="Button7"
                                    runat="server">--%>
                                <%--<input style="width: 100px" type="button" value="打印文档" id="Button6" language="javascript"
                                    onclick="return print()" size="" runat="server" />--%>
                                <% 
                                
                                if (ur == ShanliTech_HLD_Business.UserRole.Checker)
                                { %>
                                <input style="width: 84px" onclick="SignValidate()" type="button" value="核验通过并签名" id="Button10" runat="server" />
                                <input style="width: 84px" onclick="SignValidate()" type="button" value="核验不通过并签名" id="Button4" runat="server" />
                                <%}
                                else if (ur == ShanliTech_HLD_Business.UserRole.Approver)
                                { %>
                                <input style="width: 84px" onclick="SignValidate()" type="button" value="批准通过并签名" id="Button5" runat="server" />
                                <input style="width: 84px" onclick="SignValidate()" type="button" value="批准不通过并签名" id="Button7" runat="server" />
                                <%}
                                else
                                {%>
                                <input type="button" value="选择此证书模版" onclick="javascript:SelectCertifyTemplate();" style="width: 100px;" id="Button3"
                                   />
                                <asp:Button ID="Button1" runat="server" Text="提　交" OnClick="Button1_Click" />
                                <%} %>
                                <input id="Button8" type="button" value="关　闭" onclick="CloseWord();window.close()" />
                                </div>
                                </td>
                        </tr>
                    </table>
                    <table cellspacing="1" cellpadding="4" width="100%" bgcolor="#d8e1e8" border="0">
                        <tr bgcolor="#f3f8fe">
                            <td align="center" style="height: 8px">
                                <object id="FramerControl1" codebase="dsoframer.ocx" height="400px" width="99%" classid="clsid:00460182-9E5E-11D5-B7C8-B8269041DD57">
                                    <param name="_ExtentX" value="16960">
                                    <param name="_ExtentY" value="13600">
                                    <param name="BorderColor" value="-2147483632">
                                    <param name="BackColor" value="-2147483643">
                                    <param name="ForeColor" value="-2147483640">
                                    <param name="TitlebarColor" value="-2147483635">
                                    <param name="TitlebarTextColor" value="-2147483634">
                                    <param name="BorderStyle" value="1">
                                    <param name="Titlebar" value="0">
                                    <param name="Toolbars" value="1">
                                    <param name="Menubar" value="1">
                                </object>
                            </td>
                        </tr>
                    </table>
                    <%--<table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td>
                            
                            </td>
                            
                        </tr>
                    </table>--%>
                </td>
            </tr>
            <tr>
                <td height="22" background="../images/show_02.gif">
                </td>
            </tr>
        </table>
<asp:TextBox ID="Number" runat="server" style="DISPLAY: none"></asp:TextBox>
<script type="text/javascript" src="../../../js/Serial/jquery-1.6.1.min.js"></script>
<script type="text/javascript">
var cer_ver='<%=verid %>';


var isOpen=false;//是否已打开Word，用于Close释放
function CloseWord(){
    if(isOpen)
        document.all.FramerControl1.Close();
    
}
//填入数据Demo
function FillData(){
//    var val=[["Name",'1.3'],["Merray",'1.0E-3']];
var infoval=[["Customer","<%=certificate.Customer %>"],
            ["CustomerAddr","<%=certificate.CustomerAddr %>"],
            ["DeviceName","<%=certificate.DeviceName %>"],
            ["DeviceFactory","<%=certificate.DeviceFactory %>"],
            ["DeviceModel","<%=certificate.DeviceModel %>"],
            ["DeviceNum","<%=certificate.DeviceNum %>"],
            ["AccuracyLevel","<%=certificate.AccuracyLevel %>"],
            ["Verification","<%=certificate.Verification %>"],
            ["Verifier","<%=certificate.Verifier %>"],
            ["ValidateTime","<%=certificate.VerifyTime %>"],
            ["DeptCertificateNum","<%=certificate.DeptCertificateNum %>"],
            ["DeptFax","<%=certificate.DeptFax %>"],
            ["DeptPhone","<%=certificate.DeptPhone %>"],
            ["DeptPostCode","<%=certificate.DeptPostCode %>"],
            ["DeptPostAddr","<%=certificate.DeptPostAddr %>"],
            ["DeptAddr","<%=certificate.DeptAddr %>"],
            ["DueToTime","<%=certificate.DueToTime %>"],
            ["VerifyAddr","<%=certificate.VerifyAddr %>"],
            ["Temperature","<%=certificate.Temperature %>"],
            ["Humidity","<%=certificate.Humidity %>"],
            ["NoteExt","<%=certificate.NoteExt %>"]];
            
    for(var i=0;i<infoval.length;i++){
        ReplaceMark(infoval[i][0],infoval[i][1]);
    }
    //所使用的标准器具
    var titles = ["名称","型号","测量范围","扩展不确定度","证书号/有效期限"] ;
    var standardlist='<%=standardlist %>';
    standardlist=jQuery.parseJSON(standardlist);
    InsertTableListMark("List_Standard",titles,standardlist.standard);
    //所依据的技术规范（编号、名称）
    var docs='<%=basic %>';
    docs=jQuery.parseJSON(docs);
    ReplaceMark("List_Docs",docs.basic);
    //[['1','200mA','+20.000','+19.988','±2.4×10﹣³','-6.0×10﹣4','合格'],['2','200mA','+100.000','+99.975','±8.0×10﹣4','-2.5×10﹣4','合格'],['3','200mA','+190.000','+189.962','±6.1×10﹣4','-2.0×10﹣4','合格']];
    var titles2 = ["序号","量程","频率","标准值","实际值","最大允许误差","实际误差","结论"] ;
    var election='<%=election %>';
    election=jQuery.parseJSON(election);
    InsertTableListMark("List_DCV",titles2,election.dcv);
    InsertTableListMark("List_ACI",titles2,election.aci);
    InsertTableListMark("List_ACV",titles2,election.acv);
    
    
}
var CertifyTemplate;
//选择证书模板
function SelectCertifyTemplate(){
    CertifyTemplate = $('#<%=Doc_DropDown.ClientID %>').val();
    
	if (CertifyTemplate=='0')
	{
	    alert("请先选择证书模板文件！");
		return false; 
	} 
	else
	{
	    if (!confirm("确定选择此证书模板文件？"))
            return false;
        if(CertifyTemplate==cer_ver)
            CertifyTemplate="RedHeader_First.doc";
        var server=window.location.host;
		document.all.FramerControl1.Open("http://"+server+"/Manager/DocTemplates/"+CertifyTemplate,true);
		isOpen=true;
		FillData(); //并填充数据
	}
}

//保存到服务器
function SaveToWeb(){
//          showwait();	
	document.all.FramerControl1.SetTrackRevisions(0);
    var serverpath=window.location.host; 
   document.all.FramerControl1.HttpInit();
            document.all.FramerControl1.HttpAddPostString("RecordID","200601022");
            document.all.FramerControl1.HttpAddPostString("UserID","李局长");
            document.all.FramerControl1.HttpAddPostCurrFile("FileData", "bbb.doc");
                                       
    document.all.FramerControl1.HttpPost("http://"+serverpath+"/Manager/Module/ShanliTech_HLD/Document/Doc_Online_Save.aspx?file="+CertifyTemplate+"&number=<%=number %>&forname=<%=forname %>");
} 

//电子签名身份认证
function SignValidate(){
    //控件宽
    var aw = 420;
    //控件高
    var ah = 320;
    //计算控件水平位置
    var al = (screen.width - aw)/2-100;
    //计算控件垂直位置
    var at = (screen.height - ah)/5;
    mytop=screen.availHeight-500;
    myleft=200;
    window.open("../SignValidate.aspx?Number=<%=number %>","online","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
}

//签入电子签名
function OpenSealToWeb(signfile){
   var serverpath=window.location.host;
   var file = "http://"+serverpath+"/Manager/Public/SignPictures/"+signfile;
   document.all.FramerControl1.DownloadFile(file,"D:\\"+signfile);
   document.all.FramerControl1.SetFieldValue("Sign","","");
   document.all.FramerControl1.InSertFile("D:\\"+signfile,8);
}	

//单个字段替换
function ReplaceMark(key,value){
	document.all.FramerControl1.SetFieldValue(key,value,"");
}

//插入数据表格
function InsertTableListMark(key,titleArray,dataArray){
	wordcontorl(titleArray,dataArray,key);
	document.all.FramerControl1.SetFieldValue(key,"D:\\"+key+".doc","::FILE::");
}
function wordcontorl(titleArray,dataArray,tmpfile){ 
    var col=titleArray.length;
    var row=dataArray.length+1; //存在标题行

    var WordApp=new ActiveXObject("Word.Application"); 
    var wdCharacter=1 ;
    var wdOrientLandscape = 1 ;
    WordApp.Application.Visible=false; //执行完成之后是否弹出已经生成的word 
    var myDoc=WordApp.Documents.Add();//创建新的空文档 
    //WordApp.ActiveDocument.PageSetup.Orientation = wdOrientLandscape//页面方向设置为横向 
    //WordApp. Selection.ParagraphFormat.Alignment=1 //1居中对齐,0为居右 
    WordApp. Selection.Font.Bold=true;
    WordApp. Selection.Font.Size=12 ;
    //WordApp. Selection.TypeText("熊猫烧香"); 
    //WordApp. Selection.MoveRight(wdCharacter);　　　　//光标右移字符 
    //WordApp.Selection.TypeParagraph();　　　　　　　　　//插入段落 
    //WordApp. Selection.Font.Size=12; 
    //WordApp. Selection.TypeText("-----Heaven编写"); //分行插入日期 
    //WordApp.Selection.TypeParagraph()　　　　　　　　　//插入段落 
    var myTable=myDoc.Tables.Add (WordApp.Selection.Range,row, col) //4行7列的表格 
    //myTable.Style="网格型";
//    var titles = ["序号","量程","标准值","实际值","最大允许误差","实际误差","结论"] ;
    var TableRange; //以下为给表格中的单元格赋值 
    for (i= 0;i<col;i++) 
    { 
        with (myTable.Cell(1,i+1).Range) 
        { 
            
            font.Size = 8; 
            InsertAfter(titleArray[i]); 
            ColumnWidth =4 ;
        } 
    } 
//    var data=[['1','200mA','+20.000','+19.988','±2.4×10﹣³','-6.0×10﹣4','合格'],['2','200mA','+100.000','+99.975','±8.0×10﹣4','-2.5×10﹣4','合格'],['3','200mA','+190.000','+189.962','±6.1×10﹣4','-2.0×10﹣4','合格']];
    if(dataArray.length>0)
    {
        for (n =0;n<row-1;n++)  //去除标题行
        { 
            for (i =0;i<col ;i++) 
            { 
                with (myTable.Cell(n+2,i+1).Range) 
                {
                    font.Size = 8;
                    InsertAfter(dataArray[n][i]); 
                } 
            } 
        } 
    }
    //row_count = 0; 
    //col_count = 0 ;
    myDoc.Protect(1) ;
    WordApp.ActiveDocument.SaveAs("D:\\"+tmpfile+".doc");
    WordApp.Quit();
} 

//打印相关
function print(){
   document.all.FramerControl1.PrintOut();
}
function printview(){
    document.all.FramerControl1.PrintPreview();
}
function printviewexit(){
    document.all.FramerControl1.PrintPreviewExit();
}

</script>
<%--<script>
		var v_online_path = "/Manager/DocTemplates";
		
		function ReplaceMark(){
		    document.all.FramerControl1.SetFieldValue("Name","Heaven","");
		    document.all.FramerControl1.SetFieldValue("Merray","结婚了","");
		    
		}
		
		function AddMark(){
		    var serverpath=window.location.host+v_online_path; 
		   //document.all.FramerControl1.SetFieldValue("List",wordcontorl(),"");
		   wordcontorl();
		   document.all.FramerControl1.SetFieldValue("List","D:\\tmp2.doc","::FILE::");
		}
		
		function  wordcontorl(){ 
var WordApp=new ActiveXObject("Word.Application"); 
var wdCharacter=1 ;
var wdOrientLandscape = 1 ;
WordApp.Application.Visible=false; //执行完成之后是否弹出已经生成的word 
var myDoc=WordApp.Documents.Add();//创建新的空文档 
//WordApp.ActiveDocument.PageSetup.Orientation = wdOrientLandscape//页面方向设置为横向 
//WordApp. Selection.ParagraphFormat.Alignment=1 //1居中对齐,0为居右 
WordApp. Selection.Font.Bold=true;
WordApp. Selection.Font.Size=12 ;
//WordApp. Selection.TypeText("熊猫烧香"); 
//WordApp. Selection.MoveRight(wdCharacter);　　　　//光标右移字符 
//WordApp.Selection.TypeParagraph();　　　　　　　　　//插入段落 
//WordApp. Selection.Font.Size=12; 
//WordApp. Selection.TypeText("-----Heaven编写"); //分行插入日期 
//WordApp.Selection.TypeParagraph()　　　　　　　　　//插入段落 
var myTable=myDoc.Tables.Add (WordApp.Selection.Range, 4,7) //4行7列的表格 
//myTable.Style="网格型";

var titles = ["序号","量程","标准值","实际值","最大允许误差","实际误差","结论"] ;
var TableRange; //以下为给表格中的单元格赋值 
for (i= 0;i<7;i++) 
{ 
myTable.Cell(1,i+1).Borders[1].ArtWidth=5;
with (myTable.Cell(1,i+1).Range) 
{ 
//style.BorderTop = 1.5;
font.Size = 8; 
InsertAfter(titles[i]); 
ColumnWidth =4 ;
} 
} 
var data=[['1','200mA','+20.000','+19.988','±2.4×10﹣³','-6.0×10﹣4','合格'],['2','200mA','+100.000','+99.975','±8.0×10﹣4','-2.5×10﹣4','合格'],['3','200mA','+190.000','+189.962','±6.1×10﹣4','-2.0×10﹣4','合格']];
for (n =0;n<3;n++) 
{ 
    for (i =0;i<7 ;i++) 
    { 
        with (myTable.Cell(n+2,i+1).Range) 
        {
            font.Size = 8;
            InsertAfter(data[n][i]); 
        } 
    } 
} 
//row_count = 0; 
//col_count = 0 ;
myDoc.Protect(1) ;
WordApp.ActiveDocument.SaveAs("D:\\tmp2.doc");
WordApp.Quit();
} 
		
		function chknull()
		{
			
			document.all.FramerControl1.caption = "在线编辑：<%=forname%>";
			var serverpath=window.location.host+v_online_path; 
			
			var num=Math.random();
//			document.all.FramerControl1.Open("http://"+serverpath+"/WorkFlow/AddWorkFlowFj/<%=forfile%>?tmp="+num+"", true);
			//document.all.FramerControl1.Open("http://192.168.1.111/SystemManage/DocumentModle/20081222315147148009.doc?tmp="+num+"", true);
			//alert("http://"+serverpath+"/SystemManage/DocumentModle/<%=forfile%>?tmp="+num+"");
			
	
			
		}              
 

	
//		function Track()
//		{
//	        document.all.FramerControl1.SetTrackRevisions(1);
//			document.all.FramerControl1.SetCurrUserName("<%=realname%>");	
//          document.all.FramerControl1.SetCurrTime("2006:02:07 11:11:11");

//		}	
			
	
		            
      
        function SaveToWeb()
        {
          showwait();	
			document.all.FramerControl1.SetTrackRevisions(0);
            var serverpath=window.location.host+v_online_path; 
            document.all.FramerControl1.HttpInit();
            document.all.FramerControl1.HttpAddPostString("RecordID","200601022");
            document.all.FramerControl1.HttpAddPostString("UserID","李局长");
            document.all.FramerControl1.HttpAddPostCurrFile("FileData", "bbb.doc");
    
              
//           document.all.FramerControl1.HttpPost("http://"+serverpath+"/WorkFlow/Document_online_save.aspx?file=<%=forfile%>&number=<%=number%>&forname=<%=forname%>");
      
	
      
        } 
        
        function Track(){
            document.all.FramerControl1.SetTrackRevisions(1);
			document.all.FramerControl1.SetCurrUserName("<%=realname%>");	
        }
        function UnTrack(){
            document.all.FramerControl1.SetTrackRevisions(0);
          
        }

        function print(){
        document.all.FramerControl1.PrintOut();
           
         }
         function printview(){
        
        document.all.FramerControl1.PrintPreview();
           
         }
         function printviewexit(){
        
        document.all.FramerControl1.PrintPreviewExit();
           
         }

        
        function clearTrack(){
           document.all.FramerControl1.SetTrackRevisions(4);
        }	
        
		 function OpenToWeb()
		 {
		 
			if (document.getElementById('Doc_DropDown').value=="请选择")
			{
				alert("请先选择红头文件！"); 
				return(false); 
			} 
			else
			{
			    if (!confirm("插入红头文件到光标停留处？"))
                return false;
                
				var fileName = document.getElementById('Doc_DropDown').value; 
				var server=window.location.host;
				var serverpath=window.location.host+v_online_path; 
				
				document.all.FramerControl1.Open("http://"+serverpath+"/"+fileName+"",true);
			}
		
    
		 }        
        
        function openyz()
        {
            //控件宽
            var aw = 420;
            //控件高
            var ah = 320;
            //计算控件水平位置
            var al = (screen.width - aw)/2-100;
            //计算控件垂直位置
            var at = (screen.height - ah)/5;
            
            mytop=screen.availHeight-500;
            myleft=200;
//            window.open("WorkFlowListSpYz.aspx?Number=<%=number%>","online","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
       
        }
 
 
        function OpenSealToWeb(){
           var serverpath=window.location.host; 
           var file = "http://"+serverpath+"/Manager/Public/SignPictures/sign.png";
           document.all.FramerControl1.DownloadFile(file,"D:\\ss.png");
           document.all.FramerControl1.SetFieldValue("Sign","","");
           
           document.all.FramerControl1.InSertFile("D:\\ss.png",8);
        }	
    </script>--%>
</asp:Content>
