import {Http, Headers} from "@angular/http";
import {Injectable} from "@angular/core";
import {NavigationMenu, NavigationMenuItem} from "../interfaces/inavigation";
//import "rxjs/Rx";

@Injectable()
export class NavigationService {
    constructor(private http: Http) { }

    getMenuItemsByMenuNameAndMenuItemId(name: string, id: number, routeName: string, onNext: (json: NavigationMenuItem) => void) {
        this.http.get("api/cms/navigationmenu/getmenuitemsbymenunameandmenuitemid/?name=" + name + "&id=" + id + "&routeName=" + routeName).map(response => response.json()).subscribe(onNext);
    }
}