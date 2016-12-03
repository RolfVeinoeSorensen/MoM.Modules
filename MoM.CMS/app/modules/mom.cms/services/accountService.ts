import {Http, Headers} from "@angular/http";
import {Injectable} from "@angular/core";

import {Observable} from "rxjs/Observable";
import "rxjs/add/operator/map";
import "rxjs/add/operator/share";

@Injectable()
export class AccountService {
    constructor(private http: Http) { }

    logOff(onNext: (json: any) => void) {
        var headers = new Headers();
        headers.append("Content-Type", "application/json");
        this.http.post("account/logoff", "", { headers }).map(response => response.json()).subscribe(onNext);
    }
}