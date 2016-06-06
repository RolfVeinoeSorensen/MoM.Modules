
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



import {NavigationMenuItemDto} from "../dtos/NavigationMenuItemDto";

@Injectable()
export class NavigationMenuService {
    constructor(private _http: Http) { }
    
    
    public getMenuItemsByMenuNameAndMenuItemId = (name: string, id: number, routeName: string) : Observable<NavigationMenuItemDto[]> => {
        return this._http.request(`getmenuitemsbymenunameandmenuitemid?name=${name}&id=${id}&routeName=${routeName}`, new RequestOptions({
            method: "get",
            body: JSON.stringify(null)
        })).map(res => (<NavigationMenuItemDto[]>res.json()));
    }
    
}