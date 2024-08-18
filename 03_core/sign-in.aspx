<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sign-in.aspx.cs" Inherits="sign_in" %>



<!DOCTYPE html>
<html lang="en">
<head runat="server">
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
	<main class="auth auth-floated">
		<!-- form -->
		<form class="auth-form" runat="server">
			<div class="mb-4">
				<div class="mb-3">
					<img class="rounded" src="assets/apple-touch-icon.png" alt="" height="72">
				</div>
				<h1 class="h3">INGRESO </h1>
			</div>
			<p class="text-left mb-4">
				No tienes cuenta?
          solicita acceso a Soledad Suarez
       
			</p>
			<!-- .form-group -->
			<div class="form-group mb-4">
				<label class="d-block text-left" for="txtUser">Usuario</label>
				<asp:TextBox ID="txtUser" CssClass="form-control form-control-lg" runat="server" required="" autofocus=""></asp:TextBox>

			</div>
			<!-- /.form-group -->
			<!-- .form-group -->
			<div class="form-group mb-4">
				<label class="d-block text-left" for="txtPassword">Clave</label>
				<asp:TextBox ID="txtPassword" CssClass="form-control form-control-lg" runat="server" TextMode="Password" required=""></asp:TextBox>
			</div>
			<!-- /.form-group -->
			<!-- .form-group -->
			<div class="form-group mb-4">
				<asp:Button ID="btnIngresar" class="btn btn-lg btn-primary btn-block" Text="Ingresar" runat="server" OnClick="btnIngresar_Click" />


			</div>
			<!-- /.form-group -->
			<!-- .form-group -->
			<!-- /.form-group -->
			<!-- recovery links -->
			<p class="py-3">
				<a href="auth-recovery-password.html" class="link">¿Olvidaste tu clave?</a>
			</p>
			<div class="form-group text-center">
				<div class="custom-control custom-control-inline custom-checkbox">
					&nbsp;
         
				</div>
			</div>
			<!-- /recovery links -->
			<!-- copyright -->
			<p class="px-3 text-muted text-center">
				© 2024 Todos los derechos reservados. Tramita SpA
         
				<a href="#">Privacy</a> and
         
				<a href="#">Terms</a>
			</p>



		</form>
		<!-- /.auth-form -->
		<!-- .auth-announcement -->
		<section id="announcement" class="auth-announcement" style="background-image: url(assets/images/illustration/img-1.png);">
			<div class="announcement-body">
				<h2 class="announcement-title">Preparese para rendir en el trabajo </h2>
				<div style="padding-left: 420px">
					<div class="text-left">
						<ol style="list-style: decimal">
							<li>Hacer un seguimiento del tiempo</li>
							<li>Descansar cada 90 minutos</li>
							<li>Tomar descansos junto a los colegas</li>
							<li>Ajustar la temperatura ambiente</li>
							<li>Poner orden</li>
							<li>Una sola tarea por vez</li>
						</ol>
					</div>
				</div>
			</div>
		</section>
		<!-- /.auth-announcement -->
	</main>





	<!-- /.auth -->
	<!-- BEGIN PLUGINS JS -->
	s
	<script src="assets/vendor/particles.js/particles.min.js"></script>
	<!-- END PLUGINS JS -->
	<!-- Global site tag (gtag.js) - Google Analytics -->
	<script>
		window.dataLayer = window.dataLayer || [];

		function gtag() {
			dataLayer.push(arguments);
		}
		gtag('js', new Date());
		gtag('config', 'UA-116692175-1');
	</script>


</body>
</html>
