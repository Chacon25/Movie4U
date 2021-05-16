import { Col, Row, Image, Checkbox } from "antd";

export type MovieView = {
    title: string;
    id: number;
    overview: string;
    poster_path: string;
};
export default function Display(props: MovieView) {
    return (
        <Col span={8} style={{ display: 'flex', flexDirection: 'column', alignItems: "center" }}>
            <img src={props.poster_path} width={150} alt="image poster" />
            <div style={{ maxWidth: '190px' }}><Checkbox value={props.id}>{props.title}</Checkbox></div>
        </Col>
    );

}
