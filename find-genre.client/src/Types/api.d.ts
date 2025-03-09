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
export interface IArtists {
    name: string,
    spotify?: string,
    bandcamp?: string,
    soundcloud?: string
}
export interface IGenre {
    tags: ITag[],
    description_short: string,
    artists: IArtists[],
    descriptions: string[],
    examples: string[],
    name: string,
    popularity: number,
    promoted?: string[],
    subgenres?: ISubgenre[],
    genreId: number
}