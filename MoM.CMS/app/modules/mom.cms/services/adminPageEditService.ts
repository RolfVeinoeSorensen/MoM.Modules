import { Page, PageComponent } from "../interfaces/ipage"

export class AdminPageEditService<Page> {
    originalItem: Page;
    currentItem: Page;
    setItem(item: Page) {
        this.originalItem = item;
        this.currentItem = this.clone(item);
    }
    getItem(): Page {
        return this.currentItem;
    }
    restoreItem(): Page {
        this.currentItem = this.originalItem;
        return this.getItem();
    }
    clone(item: Page): Page {
        return item;
    }
}