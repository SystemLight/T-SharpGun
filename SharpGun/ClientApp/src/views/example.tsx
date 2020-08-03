import React, {memo} from "react";
import {useSelector, useDispatch} from "react-redux";
import {PageHeader, Button, Descriptions} from "antd";
import {Link, useLocation} from "react-router-dom";

import {IDispatchReducer} from "@/types/store";
import {reducerDataSelector} from "@/store";
import {subRoute} from "@/routes";
import RouteView from "@/routes/routeView";
import {SRect} from "@/styles";

export const My = memo(function () {
    console.log("my update");

    return (<SRect>我的</SRect>);
}, () => true);

export default function Example() {
    const dispatch = useDispatch<IDispatchReducer>();
    const {pathname} = useLocation();
    const data = useSelector(reducerDataSelector);

    const onClick = () => {
        dispatch({type: "DATE"});
    };

    const isMyLink = pathname.includes("/example/my");
    const targetLink = isMyLink ? "/example" : "/example/my";

    return (
        <div className={"s-wrap"} style={{paddingTop: 15}}>
            <PageHeader
                style={{border: "1px solid rgb(235, 237, 240)"}}
                title={"示例页面"}
                onBack={() => location.href = "/"}
                extra={[
                    <Button key="btn" onClick={onClick}>改时</Button>
                ]}
            >
                <Descriptions size="small" column={3}>
                    <Descriptions.Item label="时间"> {data}</Descriptions.Item>
                    <Descriptions.Item label="内容">演示界面</Descriptions.Item>
                    <Descriptions.Item label="作者">SystemLight</Descriptions.Item>
                    <Descriptions.Item label="项目">react-webpack-ts</Descriptions.Item>
                    <Descriptions.Item label="我的">
                        <Link to={targetLink}>
                            <Button type={"link"}>{isMyLink ? "隐藏" : "显示"}我的</Button>
                        </Link>
                    </Descriptions.Item>
                </Descriptions>
            </PageHeader>
            <div style={{marginTop: 15, display: "flex", justifyContent: "center"}}>
                <RouteView routes={subRoute("example")}/>
            </div>
        </div>
    );
}
