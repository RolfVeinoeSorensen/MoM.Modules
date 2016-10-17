/// <reference path="../../../../../typings/index.d.ts" />
/// <reference path="../../../../../node_modules/zone.js/dist/zone.js.d.ts" />

// main entry point
import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { InstallModule } from "./install.module";

import {Ng2BootstrapConfig, Ng2BootstrapTheme} from "ng2-bootstrap/ng2-bootstrap";

import {InstallComponent} from "./pages/install";

Ng2BootstrapConfig.theme = Ng2BootstrapTheme.BS4;
//enableProdMode();
platformBrowserDynamic().bootstrapModule(InstallModule);