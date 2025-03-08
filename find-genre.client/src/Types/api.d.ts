export interface ITag {
    name: string,
    tagId: number
}
export interface ISubgenre {
    tags: ITag[],
    description: string,
    examples: string[],
    name: string,
    popularity?: number,
    promoted?: string[],
    subgenreId: number
}
export interface IGenre {
    tags: ITag[],
    description: string,
    examples: string[],
    name: string,
    popularity: number,
    promoted?: string[],
    subgenres?: ISubgenre[],
    genreId: number
}