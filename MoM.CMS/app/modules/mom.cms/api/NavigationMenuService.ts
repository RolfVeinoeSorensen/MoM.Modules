
// $Classes/Enums/Interfaces(filter)[template][separator]
// filter (optional): Matches the name or full name of the current item. * = match any, wrap in [] to match attributes or prefix with : to match interfaces or base classes.
// template: The template to repeat for each matched item
// separator (optional): A separator template that is placed between all templates e.g. $Properties[public $name: $Type][, ]

// More info: http://frhagn.github.io/Typewriter/

import {Injectable} from "@angular/core";
import {Http, Response, Headers, RequestOptions, RequestOptionsArgs} from "@angular/http";
import {Observable} from "rxjs/Observable";
import "rxjs/add/operator/map";
import "rxjs/add/operator/share";

// import {parseModel} from '../models/ModelHelper';



import {NavigationMenuRequestDto} from "../dtos/NavigationMenuRequestDto";
import {NavigationMenuItemDto} from "../dtos/NavigationMenuItemDto";

@Injectable()
export class NavigationMenuService {
constructor(private _http: Http) { }


    public getMenuItemsByMenuNameAndMenuItemId = (request: NavigationMenuRequestDto) : Observable<NavigationMenuItemDto[]> => {
        var headers = new Headers();
        headers.append("Content-Type", "application/json");
        return this._http.request("api/cms/getmenuitemsbymenunameandmenuitemid", new RequestOptions({
            headers: headers,
            method: "post",
            body: JSON.stringify(request)
        })).map(res => (<NavigationMenuItemDto[]>res.json()));
    }

}