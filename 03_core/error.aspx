﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" %>


<!DOCTYPE html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- End Required meta tags -->
    <!-- Begin SEO tag -->
    <title> Error 404: Page not found | Looper - Bootstrap 4 Admin Theme </title>
    <meta property="og:title" content="Error 404: Page not found">
    <meta name="author" content="Beni Arisandi">
    <meta property="og:locale" content="en_US">
    <meta name="description" content="Responsive admin theme build on top of Bootstrap 4">
    <meta property="og:description" content="Responsive admin theme build on top of Bootstrap 4">
    <link rel="canonical" href="//uselooper.com">
    <meta property="og:url" content="//uselooper.com">
    <meta property="og:site_name" content="Looper - Bootstrap 4 Admin Theme">
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
    <!-- .empty-state -->
    <main id="notfound-state" class="empty-state empty-state-fullpage bg-primary">
      <!-- .empty-state-container -->
      <div class="empty-state-container">
        <section class="card">
          <header class="card-header bg-light text-left">
            <i class="fa fa-fw fa-circle text-red"></i>
            <i class="fa fa-fw fa-circle text-yellow"></i>
            <i class="fa fa-fw fa-circle text-teal"></i>
          </header>
          <div class="card-body">
            <h1 class="state-header display-1 font-weight-bold">
              <i class="far fa-frown text-red"></i>
            </h1>
            <h2> Hemos encontrado un error</h2>
            <p class="state-description lead"> Lo siento, hemos encontrado un error y lo hemos enviado al administrador del sistema. </p>
            <div class="state-action">
              <a href="auth-error-v1.html" class="btn btn-lg btn-light">
                <i class="fa fa-angle-right"></i> Go Home</a>
            </div>
          </div>
        </section>
      </div>
      <!-- /.empty-state-container -->
    </main>
    <!-- /.empty-state -->
    <!-- BEGIN PLUGINS JS -->
    <script src="assets/vendor/particles.js/particles.min.js"></script>
    <script>
      /* particlesJS.load(@dom-id, @path-json, @callback (optional)); */
      particlesJS.load('notfound-state', 'assets/javascript/particles-error.json');
    </script>
    <!-- END PLUGINS JS -->
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