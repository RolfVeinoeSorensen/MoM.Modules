export interface Page {
    pageId: number;
    title: string;
    components: Array<PageComponent>;
}

export interface PageComponent {
    name: string;
    type: string;
    settings: Array<any>;
    content: string;
    mode: PageComponentMode;
}

enum PageComponentMode { Add, Edit };