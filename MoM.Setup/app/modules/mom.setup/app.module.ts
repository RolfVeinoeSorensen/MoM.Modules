import { NgModule }       from "@angular/core";
import { BrowserModule }  from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
/* App Root */
import { AppComponent }   from "./app.component";

/* Feature Modules */
import { DatabaseModule }    from "./pages/database/database.module";
//import { CoreModule }       from "./core/core.module";

/* Routing Module */
import { AppRoutingModule } from "./app-routing.module";

@NgModule({
  imports: [
    BrowserModule,
      DatabaseModule,
      FormsModule,
      ReactiveFormsModule,
/*
    CoreModule,
*/
    //CoreModule.forRoot({userName: "Miss Marple"}),
    AppRoutingModule
  ],
  declarations: [ AppComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }


/*
Copyright 2016 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/