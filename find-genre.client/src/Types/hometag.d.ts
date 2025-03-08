export interface ITagData {
    value: string;
    state: tagStateType;
  id: number;
}
export type tagStateType = "default" | "include" | "exclude"