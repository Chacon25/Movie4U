import { Col, Row, Image, Checkbox } from "antd";

export type MovieView = {
    title: string;
    id: number;
    overview: string;
    poster_path: string;
};

export default function Display(props: MovieView) {
    return (
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
                    <a>{props.overview}</a>
                </Row>
            </Col>
        </>
    );
}
