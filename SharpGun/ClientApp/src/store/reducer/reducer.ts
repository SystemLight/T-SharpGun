import {IReducerState, IReducerAction} from "@/types/store";

const _state: IReducerState = {
    data: "当前时间"
};

export default function reducer(state: IReducerState = _state, action: IReducerAction): IReducerState {
    switch (action.type) {
        case "DATE":
            const date = new Date();
            return {
                data: `${date.getFullYear()}-${date.getMonth()}-${date.getDate()} ${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}`
            };
        case "OTHER":
            return {
                data: "其它数据"
            };
        default:
            return state;
    }
}
