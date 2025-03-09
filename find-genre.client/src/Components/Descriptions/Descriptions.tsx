import { Title, Text } from "@mantine/core";

function Descriptions({ descs }: { descs: string[] }) {
    const items = descs.map((item, i) => {
        if (i % 2 != 0) {
            return <Title>{item}</Title>
        } else {
            return <Text>{item}</Text>
        }
})
    return (
        <>
            {items}
        </>
  );
}

export default Descriptions;