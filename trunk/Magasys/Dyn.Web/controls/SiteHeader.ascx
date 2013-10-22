﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteHeader.ascx.cs"
    Inherits="Dyn.Web.controls.SiteHeader" %>
<div id="container">
    <div id="header">
        <div id="menu_haut">
            <img alt="spacer" src="../SiteImages/spacer.gif" width="1" height="10" /><a href="../Home.aspx" class="lienHaut">INICIO</a>  |  <a href="../QuienesSomos.aspx" class="lienHaut">QUIENES SOMOS</a>  |  <a href="../Contacto.aspx" class="lienHaut">CONTACTO</a></div>
        <div id="menu_img">
            <img alt="spacer" src="../SiteImages/spacer.gif" width="100" height="5" />
            <div id="header_id">
            </div>
            <script type="text/javascript">
                var hasRightVersion = DetectFlashVer(requiredMajorVersion, requiredMinorVersion, requiredRevision);
                if (hasRightVersion) {
                    myFlashHeader('/flash/header', 820, 160, '#B9C6D2', 'header_id', 'custom.xml', 'transparent');
                }
                else {
                    alert("Your version of Flash player is rather old. We suggest you to upgrade your Flash player to version " + requiredMinorVersion + " (at least).The latest version  can be downloaded here : http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash.");
                }
            </script>
        </div>
        <div id="menu">
            <ul id="navigation">
                <li style="width: 20px;"></li>
                <li style="background: url(../SiteImages/b1.gif) no-repeat; background-position: 0px 12px;">
                    <a class="m1" href="../User/MisDatos.aspx" title="MIS DATOS">
                        <br />
                        MIS DATOS</a></li>
                <li style="background: url(../SiteImages/b2.gif) no-repeat; background-position: 0px 12px;">
                    <a class="m2" href="../User/MiCuenta.aspx" title="MI CUENTA">
                        <br />
                        MI CUENTA</a></li>
                <li style="background: url(../SiteImages/b3.gif) no-repeat; background-position: 0px 12px;">
                    <a class="m3" href="../User/MisPagos.aspx" title=" MIS PAGOS">
                        <br />
                        MIS PAGOS</a></li>
                <li style="background: url(../SiteImages/b4.gif) no-repeat; background-position: 0px 12px;">
                    <a class="m4" href="../User/RealizarReserva.aspx" title="REALIZAR RESERVA">
                        <br />
                        REALIZAR RESERVA</a></li>
                <li style="background: url(../SiteImages/b5.gif) no-repeat; background-position: 0px 12px;">
                    <a class="m5" href="../User/MisReservas.aspx" title="MIS RESERVAS">
                        <br />
                        MIS RESERVAS</a></li>
                <li style="background: url(../SiteImages/b6.gif) no-repeat; background-position: 0px 12px;">
                    <a class="m6" href="../User/Novedades.aspx" title="NOVEDADES">
                        <br />
                        NOVEDADES</a></li>              
            </ul>
        </div>
    </div>
</div>
