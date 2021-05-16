import { Col, Row, Image, Checkbox } from "antd";

export type MovieView = {
    title: string;
    id: number;
    overview: string;
    poster_path: string;
};

function onChange(checkedValues: any) {
    console.log("checked = ", checkedValues);
}
export default function Display(props: MovieView) {
    return (
        <Checkbox.Group style={{ width: "100%" }} onChange={onChange}>
            <>
                <Col span={8}>
                    <Row>
                        {" "}
                        <Image
                            width={200}
                            src={props.poster_path}
                        />
                    </Row>
                    <Row>
                        {" "}
                        <Checkbox value={props.id}>{props.title}</Checkbox>
                        <div>{props.overview}</div>
                    </Row>
                </Col>
            </>
        </Checkbox.Group>
    );
}
