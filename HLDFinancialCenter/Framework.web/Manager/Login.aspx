<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FrameWork.web.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html  xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="all" name="robots" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <title>中心财务系统管理平台</title>
    <style type="text/css">
        body, p, h1, ul, li, a
        {
            margin: 0;
            padding: 0;
        }
        ul, li, ol
        {
            list-style-type: none;
        }
        .clear
        {
            clear: both;
            font-size: 0;
            height: 0;
            line-height: 0;
        }
        body
        {
            background: #f3F3F3;
            font-size: 13px;
            font-family: Verdana, Geneva, sans-serif;
            color: #999;
        }
        a
        {
            outline: none; /*ff*/
            hide-focus: expression(this.hideFocus=true); /*ie*/
        }
        a:link, a:visited
        {
            color: #999;
            text-decoration: none;
        }
        a:hover, a:active
        {
            color: #000;
            text-decoration: none;
        }
        a.link1:link, a.link1:visited
        {
            color: #45a9d8;
            text-decoration: none;
        }
        a.link1:hover, a.link1:active
        {
            color: #0e6d9a;
            text-decoration: none;
        }
        .l
        {
            float: left;
        }
        .r
        {
            float: right;
        }
        .fy
        {
            font-family: "微软雅黑";
        }
        .ft
        {
            font-family: "微软雅黑" ,tahoma;
        }
        .fs
        {
            font-family: "宋体";
        }
        .fw
        {
            font-weight: bold;
        }
        .f12
        {
            font-size: 12px;
        }
        .headerOut
        {
            height: 80px;
        }
        .mainOut
        {
            height: 480px;
        }
        .footerOut
        {
            height: 60px;
        }
        .top
        {
            width: 100%;
            position: absolute;
            top: 50%;
            margin-top: -310px;
        }
        .m
        {
            width: 900px;
            margin: 0 auto;
        }
        .header
        {
            height: 70px;
        }
        .header_logo
        {
            float: left;
            width: 180px;
            height: 40px;
        }
        .header_link
        {
            float: right;
            line-height: 40px;
            padding-top: 25px;
        }
        .header_link a
        {
            margin: 0px 5px;
        }
        .main
        {
            background: url(/Manager/images/logon/bgimg1.gif);
            width: 902px;
            height: 500px;
            position: relative;
            margin-left: auto;
            margin-right: auto;
        }
        .main_logginBox
        {
            position: absolute;
            left: 480px;
        }
        .ml_head
        {
            height: 28px;
            padding: 25px 25px 0px 25px;
            font-size: 20px;
            overflow: hidden;
            color: #0094da;
        }
        .ml_iframe
        {
            height: 298px;
            margin: 0px 25px 0px 25px;
            overflow: hidden;
        }
        .ml_link
        {
            height: 28px;
            line-height: 28px;
            margin: 5px 25px 5px 25px;
            overflow: hidden;
        }
        .ml_link a.l
        {
            display: block;
            padding-right: 15px;
            position: relative;
        }
        .ml_link a.l .tri
        {
            background: url(../images/speed.gif) -6px -30px no-repeat;
            width: 12px;
            height: 20px;
            display: block;
            position: absolute;
            right: 0px;
            top: 6px;
        }
        .ml_link a:hover.l
        {
            color: #000;
            text-decoration: none;
        }
        .ml_link a:hover.l .tri
        {
            background: url(../images/speed.gif) -23px -30px no-repeat;
        }
        .ml_bot
        {
            padding: 0 25px;
            height: 39px;
            line-height: 39px;
            border-top: #eee 1px solid;
            background: #f5f5f5;
            color: #0094da;
        }
        .ml_bot .l
        {
            width: 220px;
            overflow: hidden;
        }
        .ml_bot .r
        {
            width: 80px;
            overflow: hidden;
            text-align: right;
        }
        .speed
        {
            width: 300px;
            bottom: 6px;
            left: 25px;
            position: absolute;
            border: #b7c2c9 1px solid;
            background: #FFF;
            font-size: 12px;
            z-index: 10;
        }
        .speed_head
        {
            height: 27px;
            line-height: 27px;
            background: url(../images/speed.gif) left top repeat-x #f1f3f5;
            padding-left: 15px;
        }
        .speed_head a
        {
            position: absolute;
            right: 10px;
            top: 8px;
            width: 12px;
            height: 15px;
            background: url(../images/speed.gif) -6px -51px no-repeat;
        }
        .speed_head a:hover
        {
            background: url(../images/speed.gif) -23px -51px no-repeat;
        }
        .speed ul.list
        {
            width: 100%;
            height: 50px;
            overflow: hidden;
        }
        .speed ul.list li
        {
            float: left;
            height: 48px;
            margin: 1px;
            border-right: #d5dbe2 1px solid;
        }
        .speed ul.list li.nb
        {
            border: none;
        }
        /*.speed ul.list li a{ width:97px; height:36px; padding-top:12px; display:block; text-align:center}*/.speed ul.list li a
        {
            width: 72px;
            height: 36px;
            padding-top: 12px;
            display: block;
            text-align: center;
        }
        .speed ul.list li a.ch
        {
            color: #000;
            text-decoration: none;
            background: url(../images/speed.gif) 0px -73px no-repeat;
        }
        .speed ul.list li a:hover
        {
            color: #000;
            text-decoration: none;
            background: url(../images/speed.gif) 0px -73px no-repeat #eaf1f6;
        }
        .speed ul.list li.nb a.ch
        {
            background: url(../images/speed.gif) -2px -73px no-repeat;
        }
        .speed ul.list li.nb a:hover
        {
            background: url(../images/speed.gif) -2px -73px no-repeat #eaf1f6;
        }
        .ml_time
        {
            position: absolute;
            top: 185px;
            left: 50%;
            margin-left: -320px;
            width: 350px;
            height: 70px;
            color: #FFF;
        }
        .ml_time_le
        {
            padding-right: 10px;
            overflow: hidden;
            height: 70px;
            font-size: 56px;
            _font-size: 56px;
        }
        .ml_time_ri
        {
            width: 40px;
            overflow: hidden;
            height: 70px;
            font-size: 12px;
        }
        .ml_time_ri .t1
        {
            padding-top: 10px;
            height: 20px;
            line-height: 20px;
            text-indent: 5px;
        }
        .ml_time_ri .t2
        {
            height: 32px;
            background: url(../images/weather.png) 0 -100px no-repeat;
            _background: url(../images/weather.gif) 0 -100px no-repeat;
        }
        .footer
        {
            height: 50px;
            padding-top: 15px;
            line-height: 18px;
            text-align: center;
        }
        .footer .r
        {
            text-align: right;
        }
        .ml_pictureBy
        {
            position: absolute;
            top: 470px;
            left: 50%;
            margin-left: -450px;
            width: 20px;
            height: 20px;
            color: #FFF;
            background: url(../images/pictureBy.png);
            _background: url(../images/pictureBy.gif);
        }
        .ml_pictureBy_on
        {
            background: url(../images/pictureBy.png) 0px -20px;
            _background: url(../images/pictureBy.gif) 0px -20px;
        }
        .ml_pictureByName
        {
            position: absolute;
            margin-top: -29px;
            margin-left: -16px;
            width: auto;
            padding: 0px 10px;
            line-height: 25px;
            color: #FFF;
            height: 25px;
            white-space: nowrap;
            -moz-opacity: 0.7;
            -webkit-opacity: 0.7;
            opacity: 0.7;
            background: rgba(0, 0, 0, 0.7) !important; /* IE无效，FF有效 */
            background: #000;
            filter: progid:DXImageTransform.Microsoft.alpha(opacity=70);
        }
        .arrow
        {
            position: absolute;
            margin-top: -4px;
            left: 5px;
            height: 5px;
            width: 9px;
            background: url(../images/arrow.gif) no-repeat;
            -moz-opacity: 0.6;
            -webkit-opacity: 0.6;
            opacity: 0.6;
            filter: progid:DXImageTransform.Microsoft.alpha(opacity=60);
            z-index: 10;
        }
        .gonggao_bg
        {
            background: #fffeeb;
            border-top: #eee 1px solid;
        }
        .gonggao
        {
            position: relative;
            padding: 3px;
            width: ;;;;;;;;text-align:center;margin:0pxauto;line-height:20px;padding-right:25px;}
        .gonggao a.gonggao_x
        {
            position: absolute;
            right: 10px;
            top: 2px;
            font-size: 16px;
            color: #999;
            font-family: Verdana, Geneva, sans-serif;
        }
        .gonggao a:hover.gonggao_x
        {
            color: #930;
        }
        .inp_lab
        {
            position: absolute;
            text-indent: 5px;
            line-height: 38px;
            color: #bbb;
            font-size: 14px;
        }
        .inp
        {
            height: 26px;
            line-height: 26px;
            border: 0;
            outline-style: none;
            -webkit-appearance: none;
        }
        .fy
        {
            font-family: "微软雅黑";
            font-size: 18px;
            right: 514px;
        }
        .inpBox
        {
            width: 296px;
            height: 38px;
            border: #b9cbdd 1px solid;
            line-height: 38px;
            overflow: hidden;
        }
        .inpBox_on
        {
            border-color: #0094da;
        }
        .btn1
        {
            width: 312px;
            height: 35px;
            line-height: 35px;
            font-size: 18px;
            text-align: center;
            border: none;
            color: #FFF;
            background: url(images/logon/login.gif) no-repeat;
            text-shadow: 0 1px 1px #006699;
            font-family: "微软雅黑" , "宋体";
            cursor: pointer;
        }
        .txtname
        {
            background: url(/Manager/images/logon/bgUserName.jpg);
            width:306px;
            height:34px;
        }
            .txtpwd
        {
            background: url(/Manager/images/logon/bgPassWord.jpg);
              width:306px;
              height:34px;
              margin-top: 38px;
        }
    </style>
</head>
<body onload="start()" onresize="Center()">
    <div class="top" id="top">
        <div class="headerOut">
            <div class="m header">
                <h1 class="header_logo">
                    <img src="/Manager/images/logon/logo_glt.gif" style="width: 283px; height: 68px" />
                </h1>
                <div class="header_link">
                </div>
            </div>
        </div>
        <!--公告1-->
        <div class="gonggao_bg" id="gonggao" style="display: none">
            <div class="gonggao" style="width: 960px; margin: 0 auto; text-align: left">
                <a href="#" class="gonggao_x" onclick="document.getElementById('gonggao').style.display='none' ">
                    x</a> aaa
            </div>
        </div>
        <!--公告1结束-->
        <div class="mainOut">
            <div class="main" id="bgimg">
                <div style="text-align: right; height: 30px; line-height: 30px; padding-right: 10px;
                    font-size: 14px; font-weight: bold;">
                    欢迎登录</div>
                <div class="main_logginBox" style="filter: Alpha(Opacity=80, FinishOpacity=75，Style=2);
                    color: #0094da; font-weight: bold">
                    <div style="padding-top: 41px; padding-left: 40px; font-size: 20px;">
                        <form id="form1" runat="server">
                        <div class="l ">
                            <div class="txtname">
                                <asp:TextBox ID="LoginName" title="请输入账号~!" CssClass="inp fy" runat="server" Style="width: 250px;
                                    margin-left: 45px;margin-top: 2px;"></asp:TextBox>
                            </div>
                            <div class="txtpwd">
                                <asp:TextBox ID="LoginPass" runat="server" class="inp fy" title="请输入密码~!" TextMode="Password"
                                    Style="width: 250px; margin-top: 2px; margin-left: 45px;" BorderStyle="Dotted"></asp:TextBox>
                            </div>
                            <asp:Button ID="Button1" runat="server" Text="" class="btn1" OnClick="Button1_Click"
                                Style="margin-top: 80px;" />
                        </div>
                        </form>
                    </div>
                </div>
                <div style="width: 100%; height: 480px;" id="bglink">
                </div>
            </div>
        </div>
        <div class="footerOut">
        <br />
            <div class="m footer f12">
                ©石家庄市善理科技软件有限公司 All Right Reserve
            </div>
        </div>
    </div>
</body>
</html>

<script type="text/javascript">
   
</script>

<script type="text/javascript">
    function start() {
        Center();
    }
    function Center() {
        var h1 = document.documentElement.clientHeight;
        var h2 = document.getElementById("gonggao").offsetHeight;
        var w1 = document.documentElement.clientWidth;
        //alert(w1)
        //alert(610+h2)
        //var h2=document.body.clientHeight;
        if (w1 > 1600) {
            document.getElementById("top").style.marginLeft = "-800px"
            document.getElementById("top").style.left = "50%";
            document.getElementById("top").style.width = "1600px"
        } else {
            document.getElementById("top").style.marginLeft = "0"
            document.getElementById("top").style.left = "0";
            document.getElementById("top").style.width = "100%"
        }
        if (document.getElementById("gonggao").style.display != "none") {
            if (h1 >= 600 + h2) {
                document.getElementById("top").style.position = "absolute"
                document.getElementById("top").style.top = "50%";
                document.getElementById("top").style.marginTop = "-310-h2/2+'px'";
                //alert(-300-h2/2+'px')
            } else {
                document.getElementById("top").style.position = "relative"
                document.getElementById("top").style.top = "0";
                document.getElementById("top").style.marginTop = "0"
            }
        } else {
            if (h1 >= 600) {
                document.getElementById("top").style.position = "absolute"
                document.getElementById("top").style.top = "50%";
                document.getElementById("top").style.marginTop = "-310px"
            } else {
                document.getElementById("top").style.position = "relative"
                document.getElementById("top").style.top = "0";
                document.getElementById("top").style.marginTop = "0px"
            }
        }
    }

</script>

