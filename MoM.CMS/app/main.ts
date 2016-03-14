/// <reference path="../../../typings/browser.d.ts" />
import {bootstrap}    from "angular2/platform/browser"
import {ROUTER_PROVIDERS} from "angular2/router";
import {HTTP_PROVIDERS} from "angular2/http";

import {AppComponent} from "./app.component"

import {enableProdMode} from 'angular2/core';

enableProdMode();
bootstrap(AppComponent, [ROUTER_PROVIDERS, HTTP_PROVIDERS]);