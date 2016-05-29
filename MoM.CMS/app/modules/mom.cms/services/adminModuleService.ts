import {Http, Headers, HTTP_PROVIDERS} from "@angular/http";
import {Injectable} from "angular2/core";
import {ExtensionInfo} from "../interfaces/iExtensionInfo";
import 'rxjs/Rx';

@Injectable()
export class AdminModuleService {
    constructor(private http: Http) { }

    getInstalledModules(onNext: (json: ExtensionInfo) => void) {
        this.http.get("api/modules/getinstalledmodules").map(response => response.json()).subscribe(onNext);
    }
}