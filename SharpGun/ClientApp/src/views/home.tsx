import React from "react";
import {Link} from "react-router-dom";
import {Button} from "antd";

export default function Home() {
    return (
        <div style={{textAlign: "center", paddingTop: 20}}>
            <Link to={"/example"}>
                <Button type={"primary"}>跳转到示例页面</Button>
            </Link>
        </div>
    );
}
