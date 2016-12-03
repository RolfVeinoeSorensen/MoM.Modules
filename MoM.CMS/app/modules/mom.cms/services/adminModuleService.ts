import {Http, Headers} from "@angular/http";
import {Injectable} from "@angular/core";
import {ExtensionInfo} from "../interfaces/iExtensionInfo";

import {Observable} from "rxjs/Observable";
import "rxjs/add/operator/map";
import "rxjs/add/operator/share";

@Injectable()
export class AdminModuleService {
    constructor(private http: Http) { }

    getInstalledModules(onNext: (json: ExtensionInfo) => void) {
        this.http.get("api/modules/getinstalledmodules").map(response => response.json()).subscribe(onNext);
    }
}