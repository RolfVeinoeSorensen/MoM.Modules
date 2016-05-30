import {Component, OnInit} from "@angular/core";
import {CAROUSEL_DIRECTIVES} from "ng2-bootstrap/ng2-bootstrap";

@Component({
    selector: "mvc",
    templateUrl: "/cms/pages/products"
})
export class ProductsComponent implements OnInit {
    public myInterval: number = 5000;
    public noWrapSlides: boolean = false;
    public slides: Array<any> = [];

    //constructor() {  }

    ngOnInit() {
        for (let i = 0; i < 4; i++) {
            this.addSlide();
        }
    }

    public addSlide(): void {
        let newWidth = 600 + this.slides.length + 1;
        this.slides.push({
            image: `//placekitten.com/${newWidth}/300`,
            text: `${["More", "Extra", "Lots of", "Surplus"][this.slides.length % 4]}
      ${["Cats", "Kittys", "Felines", "Cutes"][this.slides.length % 4]}`
        });
    }

    public removeSlide(index: number): void {
        this.slides.splice(index, 1);
    }
}