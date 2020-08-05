# AutomatedTests

Selenium is a test automation framework that enables you to test your UI.
Let's start by the simples example:

## Basic navigation

We are going to hit Google's web site just to start small.
In order to follow this tutorial, you should have the following nuget packages installed:
- Selenium.Support
- Selenium.WebDriver
- Selenium.WebDriver.ChromeDriver

## Input interacion

Let's ask Google something.
In order to perform the actions involved in asking google something we need to:
>- Navigate to a website (we already know how)
>- Identify an input of type text
>- Type something in input
>- Wait for confirmation that what we ask is there

## Round trip

Up to now we have relayed on Google to be fast enough to provide us with answers.
That, unfortunately, is not always the case, specially when *testing inhouse applications*, 
so for thoroughness let's wait some seconds before typing at the input and then close our driver