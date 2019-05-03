declare module 'salad-ui.chart' {
    export interface CirclePieOptions {
        width: number;
        height: number;
        strokeWidth: number;
        percent: number;
        strokeColor: string;
    }
    export class CirclePie extends React.Component<CirclePieOptions, {}> {

    }

    export interface BarMetricOptions {
        metricName: string;
        value: string;
        percent: number;
        metricPadding: number;
        metricColor: string;
        barHeight: number;
        barRailColor: string;
        barColor: string;
        label: string;
    }
    export class BarMetric extends React.Component<BarMetricOptions, {}> {

    }
}