<%@ Page Language="C#" AutoEventWireup="true" CodeFile="auth_code.aspx.cs" Inherits="auth_code" %>


<!DOCTYPE html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- End Required meta tags -->
    <!-- Begin SEO tag -->
	<title>CORE Tramita SpA </title>
	<meta property="og:title" content="Sign In">
	<meta name="author" content="Mario Granger">
	<meta property="og:locale" content="en_US">
	<meta name="description" content="Sistema de gestion de informacion">
	<meta property="og:description" content="Sistema de gestion de informacion">
	<meta property="og:site_name" content="Sistema de gestion de informacion">
    <script type="application/ld+json">
      {
        "name": "Looper - Bootstrap 4 Admin Theme",
        "description": "Responsive admin theme build on top of Bootstrap 4",
        "author":
        {
          "@type": "Person",
          "name": "Beni Arisandi"
        },
        "@type": "WebSite",
        "url": "",
        "headline": "Locked",
        "@context": "http://schema.org"
      }
    </script>
    <!-- End SEO tag -->
    <!-- Favicons -->
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/apple-touch-icon.png">
    <link rel="shortcut icon" href="assets/favicon.ico">
    <meta name="theme-color" content="#3063A0">
    <!-- BEGIN BASE STYLES -->
    <link rel="stylesheet" href="assets/vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/vendor/font-awesome/css/fontawesome-all.min.css">
    <!-- END BASE STYLES -->
    <!-- BEGIN THEME STYLES -->
    <link rel="stylesheet" href="assets/stylesheets/main.min.css">
    <link rel="stylesheet" href="assets/stylesheets/custom.css">
    <!-- END THEME STYLES -->
  </head>
  <body>
    <!-- .auth -->
    <main class="auth">
      <header id="auth-header" class="auth-header" style="background-image: url(assets/images/illustration/img-1.png);">
        <h1>
          <img src="assets/images/brand-inverse.png" alt="" height="72">
          <span class="sr-only">Locked Screen</span>
        </h1>
        <div class="container">
          <p>  Su código de autorización fue enviado a su correo  <br />
          </p>
        </div>
      </header>
      <!-- form -->
    <form ID="form" class="auth-form" runat="server">
        <div class="text-center mb-4">
          <h2 class="card-title"><asp:Label ID="lblNombreUsuario" runat="server"></asp:Label></h2>
          <h6 class="card-subtitle text-muted"><asp:Label ID="lblCorreo" runat="server"></asp:Label></h6>
        </div>
        <!-- .form-group -->
        <div class="form-group">
          <div class="input-group input-group-lg circle">
            <asp:TextBox ID="txtCodigo" class="form-control" placeholder="Código Autorización" required="" autofocus="" runat="server"></asp:TextBox>
            <div class="input-group-prepend"> 
              <button class="btn btn-reset text-primary px-3" type="button" onclick="document.getElementById('btnLogin').click()">
                <i class="fa fa-arrow-circle-right"></i>
              </button>
              <asp:ImageButton ID="btnLogin" class="btn btn-reset text-primary px-3" style="display:none"  OnClick="btnLogin_Click" runat="server" />
            </div>
          </div>
        </div>
        <!-- /.form-group -->
    </form>
      <!-- /.auth-form -->
      <!-- copyright -->
      <footer class="auth-footer"> © 2024 All Rights Reserved.
        <a href="#">Privacy</a> and
        <a href="#">Terms</a>
      </footer>
    </main>
    <!-- /.auth -->
    <!-- BEGIN BASE JS -->
    <script src="assets/vendor/jquery/jquery.min.js"></script>
    <script src="assets/vendor/bootstrap/js/popper.min.js"></script>
    <script src="assets/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!-- END BASE JS -->
    <!-- BEGIN PLUGINS JS -->
    <script src="assets/vendor/particles.js/particles.min.js"></script>
    <!-- END PLUGINS JS -->
    <!-- BEGIN THEME JS -->
    <script src="assets/javascript/main.min.js"></script>
    <!-- END THEME JS -->
    <script>
      /* particlesJS.load(@dom-id, @path-json, @callback (optional)); */
      particlesJS.load('auth-header', 'assets/javascript/particles.json');
    </script>
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-116692175-1"></script>
    <script>
      window.dataLayer = window.dataLayer || [];

      function gtag()
      {
        dataLayer.push(arguments);
      }
      gtag('js', new Date());
      gtag('config', 'UA-116692175-1');
    </script>
  </body>
</html>
