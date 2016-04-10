import {Http, Headers, HTTP_PROVIDERS} from "angular2/http";
import {Injectable} from "angular2/core";
import {NavigationMenu, NavigationMenuItem} from "../interfaces/inavigation";
import 'rxjs/Rx';

@Injectable()
export class NavigationService {
    constructor(private http: Http) { }

    getMenuItemsByMenuNameAndMenuItemId(name: string, id: number, onNext: (json: NavigationMenuItem) => void) {
        this.http.get("api/cms/navigationmenu/getmenuitemsbymenunameandmenuitemid/?name=" + name + "&id=" + id).map(response => response.json()).subscribe(onNext);
    }
}